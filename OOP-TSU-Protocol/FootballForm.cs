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

        public FootballForm()
        {
            InitializeComponent();

            _teams = new List<FootballTeam>();
            _teamComboItems = new List<FootballTeamComboItem>();
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

            HomeTeamInput.Items.AddRange(_teamComboItems.Cast<object>().ToArray());
            GuestTeamInput.Items.AddRange(_teamComboItems.Cast<object>().ToArray());
        }

        private void HomeTeamInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            HomeTeamInput.Enabled = false;

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
