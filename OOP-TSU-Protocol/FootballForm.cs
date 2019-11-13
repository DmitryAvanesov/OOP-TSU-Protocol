using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    public partial class FootballForm : Form
    {
        const string PathToFootballTeamTXT =
            @"C:\Users\DmitryAvanesov\source\repos\OOP-TSU-Protocol\OOP-TSU-Protocol\Data\FootballTeam.txt";

        enum EventType {Goal, YellowCard, RedCard};
        private IList<FootballTeam> _teams;
        private IList<FootballTeamComboItem> _teamComboItems;
        private IList<FootballPlayerComboItem> _playerComboItems;

        public FootballForm()
        {
            InitializeComponent();

            _teams = new List<FootballTeam>();
            _teamComboItems = new List<FootballTeamComboItem>();
            _playerComboItems = new List<FootballPlayerComboItem>();

            AddTeams();
        }

        private void AddTeams()
        {
            FootballTeam currentTeam;

            foreach (string line in File.ReadAllLines(PathToFootballTeamTXT))
            {
                currentTeam = new FootballTeam(line.Split(';'));

                _teams.Add(currentTeam);
                _teamComboItems.Add(new FootballTeamComboItem(currentTeam.Name, currentTeam));
            }

            // comboboxes for teams' choosing
            HomeTeamInput.Items.AddRange(_teamComboItems.Cast<object>().ToArray());
            GuestTeamInput.Items.AddRange(_teamComboItems.Cast<object>().ToArray());
        }

        private void HomeTeamInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            HomeTeamInput.Enabled = false;
            var selectedItem = (FootballTeamComboItem)HomeTeamInput.SelectedItem;

            Console.WriteLine(selectedItem.Team.TeamPlayers.Count);
            foreach (FootballPlayer player in selectedItem.Team.TeamPlayers)
            {
                _playerComboItems.Add(new FootballPlayerComboItem(player.Name, player));
            }
            PlayerInput.Items.AddRange(_playerComboItems.Cast<object>().ToArray());

            if (!GuestTeamInput.Enabled)
            {
                EnableInput();
            }
            else
            {
                GuestTeamInput.Items.Remove(HomeTeamInput.SelectedItem);
            }
        }

        private void GuestTeamInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            GuestTeamInput.Enabled = false;

            if (!HomeTeamInput.Enabled)
            {
                EnableInput();
            }
            else {
                HomeTeamInput.Items.Remove(GuestTeamInput.SelectedItem);
            }
        }

        private void EnableInput()
        {
            DateInput.Enabled = true;
            MinuteInput.Enabled = true;
            EventTypeInput.Enabled = true;
            PlayerInput.Enabled = true;
        }
    }
}
