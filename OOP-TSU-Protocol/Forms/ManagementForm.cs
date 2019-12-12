using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    public partial class ManagementForm<T1, T2> : Form
        where T1 : Team, new()
        where T2 : Player, new()
    {
        public MainForm MainForm;

        private UserInterface<T1, T2> _userInterface;
        private Database<T1, T2> _database;
        private ICollection<Tournament<T1, T2>> _tournaments;
        private ICollection<T1> _teams;
        private Tournament<T1, T2> _activeTournament;

        public ManagementForm(MainForm newMainForm)
        {
            InitializeComponent();

            MainForm = newMainForm;

            _userInterface = new UserInterface<T1, T2>(TournamentInput, TournamentTitleInput,
                NumberOfTeamsInput, NumberOfRowsInput, TeamInput, CurrentGameLabel, GameDateInput,
                AddTeamButton, TeamOutput, SaveDateButton);
            _database = new Database<T1, T2>(_userInterface);
            _userInterface.CurrentDatabase = _database;
            _tournaments = new List<Tournament<T1, T2>>();
            _teams = new List<T1>();
            _activeTournament = new Tournament<T1, T2>();

            AddTeams();
            AddTournaments();
        }

        private void AddTournaments()
        {
            Tournament<T1, T2> currentTournament;
            var data = _database.SelectTournaments();

            foreach (var currentTournamentData in data)
            {
                currentTournament = new Tournament<T1, T2>(currentTournamentData);
                AddTeamsToTournament(currentTournament);
                AddGamesToTournament(currentTournament);

                _tournaments.Add(currentTournament);
                _userInterface.AddTournamentComboItem(currentTournament);
            }

            if (_tournaments.Count > 0)
            {
                _userInterface.AddTournamentComboItemsToComboBox();
            }
        }

        private void AddTeamsToTournament(Tournament<T1, T2> tournament)
        {
            T1 currentTeam;
            var data = _database.SelectTeamsToTournament(tournament.Id);

            foreach (var currentTeamData in data)
            {
                currentTeam = new T1();
                currentTeam.InitializeTeam(currentTeamData, _userInterface, _database);
                tournament.Teams.Add(currentTeam);
            }
        }

        private void AddGamesToTournament(Tournament<T1, T2> tournament)
        {
            Game<T1, T2> currentGame;
            var data = _database.SelectGamesToTournament(tournament.Id);

            foreach (var currentGameData in data)
            {
                T1 homeTeam = new T1();
                T1 guestTeam = new T1();

                foreach (var currentTeam in _teams)
                {
                    if (currentTeam.Id == int.Parse(currentGameData[3]))
                    {
                        homeTeam = currentTeam;
                    }
                    else if (currentTeam.Id == int.Parse(currentGameData[4]))
                    {
                        guestTeam = currentTeam;
                    }
                }

                currentGame = new Game<T1, T2>(currentGameData, homeTeam, guestTeam);
                tournament.Games.Add(currentGame);
            }
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

        private void AddTeamButton_Click(object sender, EventArgs e)
        {
            if (_userInterface.CheckTeamSelectingCorrectness())
            {
                _activeTournament.Teams.Add(
                    ((ComboItem<T1>)_userInterface.TeamInput.SelectedItem).Object);

                if (_userInterface.ChooseTeam())
                { 
                    for (var i = 0; i < _userInterface.TeamOutput.Items.Count; i++)
                    {
                        for (var j =
                            int.Parse(_userInterface.NumberOfRowsInput.SelectedItem.ToString()) == 2 ?
                            0 : i + 1;
                            j < _userInterface.TeamOutput.Items.Count; j++)
                        {
                            if (_userInterface.TeamOutput.Items[i] !=
                                _userInterface.TeamOutput.Items[j])
                            {
                                _activeTournament.Games.Add(new Game<T1, T2>(
                                ((ComboItem<T1>)_userInterface.TeamOutput.Items[i]).Object,
                                ((ComboItem<T1>)_userInterface.TeamOutput.Items[j]).Object));
                            }
                        }
                    }

                    _userInterface.SetDateNext(_activeTournament.Games);
                }
            } 
        }

        private void NumberOfTeamsInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.CheckForDisable();

            if (_userInterface.NumberOfTeamsInput.SelectedItem != null)
            {
                _activeTournament.NumberOfTeams =
               int.Parse(_userInterface.NumberOfTeamsInput.SelectedItem.ToString());
            }
        }

        private void NumberOfRowsInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.CheckForDisable();

            if (_userInterface.NumberOfRowsInput.SelectedItem != null)
            {
                _activeTournament.NumberOfRows =
                int.Parse(_userInterface.NumberOfRowsInput.SelectedItem.ToString());
            }
        }

        private void SaveDateButton_Click(object sender, EventArgs e)
        {
            if (_userInterface.SetDateNext(_activeTournament.Games))
            {
                _activeTournament.Title = _userInterface.TournamentTitleInput.Text;

                _database.InsertTournament(_activeTournament);
                _database.InsertTournamentTeams(_activeTournament);

                foreach (var currentGame in _activeTournament.Games)
                {
                    _database.InsertGame(currentGame);
                }

                _activeTournament = new Tournament<T1, T2>();
                _userInterface.ReloadForm();
                AddTournaments();
                MessageBox.Show("Tournament created");
            }
        }

        private void SelectTournamentButton_Click(object sender, EventArgs e)
        {
            if (_userInterface.TournamentInput.SelectedItem != null)
            {
                Hide();

                var protocolForm = new ProtocolForm<T1, T2>(this, (
                    (ComboItem<Tournament<T1, T2>>)_userInterface.TournamentInput.SelectedItem).Object);
                protocolForm.Show();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Hide();
            MainForm.Show();
        }
    }
}
