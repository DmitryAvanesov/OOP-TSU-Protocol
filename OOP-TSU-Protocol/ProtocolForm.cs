using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    public partial class ProtocolForm : Form
    {
        string PathToFootballTeamTXT = @"\..\..\Data\FootballTeam.txt";

        private UserInterface _userInterface;
        private Database _database;
        private IList<FootballTeam> _teams;

        public ProtocolForm()
        {
            InitializeComponent();

            _userInterface = new UserInterface(HomeTeamInput, GuestTeamInput, DateInput,
                MinuteInput, EventTypeInput, PlayerInput, AddEventButton);
            _database = new Database(_userInterface);
            _userInterface.CurrentDatabase = _database;
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
                _userInterface.AddTeamComboItem(currentTeam);
            }

            _userInterface.AddTeamComboItemsToComboBox();
        }

        private void HomeTeamInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.OnTeamInputIndexChange(HomeTeamInput, GuestTeamInput);
        }

        private void GuestTeamInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.OnTeamInputIndexChange(GuestTeamInput, HomeTeamInput);
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            _database.InsertEvent();
        }
    }
}