using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    public partial class ProtocolForm : Form
    {
        string PathToFootballTeamTXT = @"\..\..\Data\FootballTeam.txt";

        UserInterface userInterface;
        private IList<FootballTeam> _teams;

        public ProtocolForm()
        {
            InitializeComponent();

            userInterface = new UserInterface(HomeTeamInput, GuestTeamInput, DateInput, MinuteInput, EventTypeInput, PlayerInput);
            _teams = new List<FootballTeam>();
            AddTeams();
        }

        private void AddTeams()
        {
            FootballTeam currentTeam;

            foreach (string line in File.ReadAllLines(Directory.GetCurrentDirectory() + PathToFootballTeamTXT))
            {
                currentTeam = new FootballTeam(line.Split(';'));
                _teams.Add(currentTeam);
                userInterface.AddTeamComboItem(currentTeam);
            }

            userInterface.AddTeamComboItemsToComboBox();
        }

        private void HomeTeamInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            userInterface.OnTeamInputIndexChange(HomeTeamInput, GuestTeamInput);
        }

        private void GuestTeamInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            userInterface.OnTeamInputIndexChange(GuestTeamInput, HomeTeamInput);
        }
    }
}
