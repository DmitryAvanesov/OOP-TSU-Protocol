using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    public partial class ManagementForm<T1, T2> : Form
        where T1 : Team, new()
        where T2 : Player, new()
    {
        private MainForm _mainForm;

        private UserInterface<T1, T2> _userInterface;
        private Database<T1, T2> _database;
        private ICollection<Tournament<T1, T2>> _tournaments;
        private ICollection<T1> _teams;
        private Tournament<T1, T2> _activeTournament;

        public ManagementForm(MainForm newMainForm)
        {
            InitializeComponent();

            _mainForm = newMainForm;

            _userInterface = new UserInterface<T1, T2>(TournamentTitleInput, NumberOfTeamsInput,
                NumberOfRowsInput, TeamInput, CurrentGameLabel, GameDateInput, AddTeamButton,
                TeamOutput, SaveDateButton);
            _database = new Database<T1, T2>(_userInterface);
            _userInterface.CurrentDatabase = _database;
            _tournaments = new List<Tournament<T1, T2>>();
            _teams = new List<T1>();
            _activeTournament = new Tournament<T1, T2>();

            AddTeams();
        }

        private void AddTeams()
        {
            T1 currentTeam = new T1();
            var data = _database.SelectTeams();

            foreach (var currentTeamData in data)
            {
                currentTeam.InitializeTeam(currentTeamData, _userInterface, _database);
                _teams.Add(currentTeam);
                _userInterface.AddTeamComboItem(currentTeam);
                currentTeam = new T1();
            }

            _userInterface.AddTeamComboItemsToComboBox();
        }

        private void CreateTournamentButton_Click(object sender, EventArgs e)
        {

        }

        private void AddTeamButton_Click(object sender, EventArgs e)
        {
            if (_userInterface.CheckTeamSelectingCorrectness())
            {
                _activeTournament.Teams.Add(
                    ((ComboItem<T1>)_userInterface.TeamInput.SelectedItem).Object);
                _userInterface.ChooseTeam();
            } 
        }

        private void NumberOfTeamsInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.CheckForDisable();
            _activeTournament.NumberOfTeams =
                int.Parse(_userInterface.NumberOfTeamsInput.SelectedItem.ToString());
        }

        private void NumberOfRowsInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.CheckForDisable();
            _activeTournament.NumberOfRows =
                int.Parse(_userInterface.NumberOfRowsInput.SelectedItem.ToString());
        }

        private void SaveDateButton_Click(object sender, EventArgs e)
        {
            _userInterface.SetDateNext(_activeTournament.Teams);
        }
    }
}
