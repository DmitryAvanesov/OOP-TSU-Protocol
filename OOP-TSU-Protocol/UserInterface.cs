using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    public class UserInterface<T1, T2>
        where T1 : Team, new()
        where T2 : Player, new()
    {
        public ComboBox TournamentInput { get; private set; }
        public TextBox TournamentTitleInput { get; private set; }
        public ComboBox NumberOfTeamsInput { get; private set; }
        public ComboBox NumberOfRowsInput { get; private set; }
        public ComboBox TeamInput { get; private set; }
        public ListBox TeamOutput { get; private set; }
        public Label CurrentGameLabel { get; private set; }
        public DateTimePicker GameDateInput { get; private set; }
        public ComboBox ProtocolInput { get; private set; }
        public ComboBox StatsInput { get; private set; }
        public ComboBox GameInput { get; private set; }
        public DateTimePicker DateInput { get; private set; }
        public NumericUpDown MinuteInput { get; private set; }
        public ComboBox EventTypeInput { get; private set; }
        public ComboBox PlayerInput { get; private set; }
        public Label AssistantLabel { get; private set; }
        public ComboBox AssistantInput { get; private set; }
        private Button _addTeamButton;
        private Button _saveDateButton;
        private Button _addEventButton;
        private Button _saveProtocolButton;
        private Button _backButton;
        private Panel _eventsPanel;

        private ICollection<ComboItem<Tournament<T1, T2>>> _tournamentComboItems;
        private ICollection<ComboItem<Game<T1, T2>>> _gameComboItems;
        private ICollection<ProtocolForm<T1, T2>.StatsType> _statsComboItems;
        private ICollection<ComboItem<T1>> _teamComboItems;
        private ICollection<ComboItem<T2>> _playerComboItems;
        private ICollection<ProtocolForm<T1, T2>.EventType> _eventComboItems;

        public Database<T1, T2> CurrentDatabase { get; set; }
        public bool GameCreated { get; private set; }
        private int _eventLabelPosition;
        private int _leftMargin;
        private int _stepMargin;
        private int _fontSize;
        private int _scheduleCurrentTeam;

        public UserInterface(ComboBox newTournamentInput, TextBox newTournamentTitleInput,
            ComboBox newNumberOfTeamsInput, ComboBox newNumberOfRowsInput, ComboBox newTeamInput,
            Label newCurrentGameLabel, DateTimePicker newGameDateInput, Button newAddTeamButton,
            ListBox newTeamOutput, Button newSaveDateButton)
        {
            TournamentInput = newTournamentInput;
            TournamentTitleInput = newTournamentTitleInput;
            NumberOfTeamsInput = newNumberOfTeamsInput;
            NumberOfRowsInput = newNumberOfRowsInput;
            TeamInput = newTeamInput;
            TeamOutput = newTeamOutput;
            CurrentGameLabel = newCurrentGameLabel;
            GameDateInput = newGameDateInput;
            _addTeamButton = newAddTeamButton;
            _saveDateButton = newSaveDateButton;

            _tournamentComboItems = new List<ComboItem<Tournament<T1, T2>>>();
            _teamComboItems = new List<ComboItem<T1>>();

            _scheduleCurrentTeam = 0;
        }

        public UserInterface(ComboBox newProtocolInput, ComboBox newStatsInput,
            ComboBox newGameInput, NumericUpDown newMinuteInput,
            ComboBox newEventTypeInput, ComboBox newPlayerInput,
            Label newAssistantLabel, ComboBox newAssistantInput, Button newAddEventButton,
            Button newSaveProtocolButton, Button newBackButton, Panel newEventsPanel)
        {
            ProtocolInput = newProtocolInput;
            StatsInput = newStatsInput;
            GameInput = newGameInput;
            MinuteInput = newMinuteInput;
            EventTypeInput = newEventTypeInput;
            PlayerInput = newPlayerInput;
            AssistantLabel = newAssistantLabel;
            AssistantInput = newAssistantInput;
            _addEventButton = newAddEventButton;
            _saveProtocolButton = newSaveProtocolButton;
            _backButton = newBackButton;
            _eventsPanel = newEventsPanel;

            _tournamentComboItems = new List<ComboItem<Tournament<T1, T2>>>();
            _gameComboItems = new List<ComboItem<Game<T1, T2>>>();
            _statsComboItems = new List<ProtocolForm<T1, T2>.StatsType>();
            _teamComboItems = new List<ComboItem<T1>>();
            _playerComboItems = new List<ComboItem<T2>>();
            _eventComboItems = new List<ProtocolForm<T1, T2>.EventType>();

            GameCreated = false;
            _eventLabelPosition = 20;
            _leftMargin = 20;
            _stepMargin = 50;
            _fontSize = 16;

            if (typeof(T1) == typeof(FootballTeam))
            {
                MinuteInput.Maximum = 90;
            }
            else if (typeof(T1) == typeof(BasketballTeam))
            {
                MinuteInput.Maximum = 40;
            }
        }

        //////////////////////////////// MANAGEMENT FORM METHODS //////////////////////////////////


        public void AddTournamentComboItem(Tournament<T1, T2> currentTournament)
        {
            _tournamentComboItems.Add(
                new ComboItem<Tournament<T1, T2>>(currentTournament.Title, currentTournament));
        }

        public void AddTournamentComboItemsToComboBox()
        {
            TournamentInput.Items.Clear();
            TournamentInput.Items.AddRange(_tournamentComboItems.Cast<object>().ToArray());
            _tournamentComboItems.Clear();
        }

        public void AddTeamComboItem(T1 currentTeam)
        {
            _teamComboItems.Add(new ComboItem<T1>(currentTeam.Name, currentTeam));
        }

        public void AddTeamComboItemsToComboBox()
        {
            TeamInput.Items.AddRange(_teamComboItems.Cast<object>().ToArray());
        }

        public void CheckForDisable()
        {
            if (NumberOfTeamsInput.SelectedItem != null &&
                NumberOfRowsInput.SelectedItem != null)
            {
                NumberOfTeamsInput.Enabled = false;
                NumberOfRowsInput.Enabled = false;
                TeamInput.Enabled = true;
                _addTeamButton.Enabled = true;
            }
        }

        public bool CheckTeamSelectingCorrectness()
        {
            if (TeamInput.SelectedItem != null &&
                TeamOutput.Items.Count < int.Parse(NumberOfTeamsInput.SelectedItem.ToString()))
            {
                return true;
            }

            return false;
        }

        public bool ChooseTeam()
        {
            TeamOutput.Items.Add(TeamInput.SelectedItem);
            TeamInput.Items.RemoveAt(TeamInput.SelectedIndex);

            if (TeamOutput.Items.Count == int.Parse(NumberOfTeamsInput.SelectedItem.ToString()))
            {
                GameDateInput.Enabled = true;
                _saveDateButton.Enabled = true;
                TeamInput.Enabled = false;
                _addTeamButton.Enabled = false;

                return true;
            }

            return false;
        }

        public bool SetDateNext(IList<Game<T1, T2>> games)
        {
            if (_scheduleCurrentTeam < games.Count)
            {
                CurrentGameLabel.Text = games[_scheduleCurrentTeam].Name;

                if (_scheduleCurrentTeam > 0)
                {
                    games[_scheduleCurrentTeam - 1].Date = GameDateInput.Value;
                }

                _scheduleCurrentTeam++;

                return false;
            }

            return true;
        }

        public void ReloadForm()
        {
            NumberOfTeamsInput.Enabled = true;
            NumberOfRowsInput.Enabled = true;
            TeamInput.Enabled = false;
            _addTeamButton.Enabled = false;
            GameDateInput.Enabled = false;
            _saveDateButton.Enabled = false;

            TournamentTitleInput.Text = "";
            NumberOfTeamsInput.SelectedItem = null;
            NumberOfRowsInput.SelectedItem = null;
            TeamInput.SelectedItem = null;
            TeamOutput.Items.Clear();
        }

        //////////////////////////////// PROTOCOL FORM METHODS //////////////////////////////////

        public void AddStatsTypeItems(Dictionary<ProtocolForm<T1, T2>.StatsType, Type> statsTypes)
        {
            foreach (KeyValuePair<ProtocolForm<T1, T2>.StatsType, Type> type in statsTypes)
            {
                if (type.Value == typeof(T2))
                {
                    _statsComboItems.Add(type.Key);
                }
            }

            StatsInput.Items.AddRange(_statsComboItems.Cast<object>().ToArray());
        }

        public void AddEventTypeItems(Dictionary<ProtocolForm<T1, T2>.EventType, Type> eventTypes)
        {
            foreach (KeyValuePair<ProtocolForm<T1, T2>.EventType, Type> type in eventTypes)
            {
                if (type.Value == typeof(T2))
                {
                    _eventComboItems.Add(type.Key);
                }
            }

            EventTypeInput.Items.AddRange(_eventComboItems.Cast<object>().ToArray());
        }

        public void AddProtocolComboItem(Game<T1, T2> currentGame)
        {
            _gameComboItems.Add(new ComboItem<Game<T1, T2>>(currentGame.Name, currentGame));
        }

        public void AddProtocolComboItemsToComboBox()
        {
            ProtocolInput.Items.AddRange(_gameComboItems.Cast<object>().ToArray());
        }

        public void AddPlayerComboItem(T2 currentPlayer)
        {
            _playerComboItems.Add(new ComboItem<T2>(currentPlayer.Name, currentPlayer));
        }

        public void AddPlayerComboItemsToComboBoxes()
        {
            PlayerInput.Items.AddRange(_playerComboItems.Cast<object>().ToArray());
            AssistantInput.Items.AddRange(_playerComboItems.Cast<object>().ToArray());
            _playerComboItems.Clear();
        }

        public void OnGameInputIndexChanged()
        {
            _eventsPanel.Controls.Clear();
            _eventLabelPosition = 20;

            foreach (var currentEvent in
                ((ComboItem<Game<T1, T2>>)ProtocolInput.SelectedItem).Object.Events)
            {
                WriteEvent(currentEvent);
            }
        }

        public void OnTeamInputIndexChange(ComboBox thisTeamInput, ComboBox otherTeamInput)
        {
            thisTeamInput.Enabled = false;
            var selectedItem = (ComboItem<T1>)thisTeamInput.SelectedItem;

            foreach (T2 player in selectedItem.Object.Players)
            {
                AddPlayerComboItem(player);
            }

            AddPlayerComboItemsToComboBoxes();

            if (!otherTeamInput.Enabled)
            {
                EnableInput();
            }
            else
            {
                otherTeamInput.Items.Remove(thisTeamInput.SelectedItem);
            }
        }

        public void OnEventTypeInputIndexChange()
        {
            if ((ProtocolForm<T1, T2>.EventType)EventTypeInput.SelectedItem ==
                ProtocolForm<T1, T2>.EventType.Goal)
            {
                AssistantLabel.Visible = true;
                AssistantInput.Visible = true;
            }
            else
            {
                AssistantLabel.Visible = false;
                AssistantInput.Visible = false;
                AssistantInput.SelectedItem = null;
            }
        }

        public void WriteEvent(Event<T1, T2> currentEvent)
        {
            Label eventLabel = new Label
            {
                Text = $"{currentEvent.Minute}'  |  " +
                $"{currentEvent.Type.ToString()}  |  " +
                $"{currentEvent.Player.Name} " +
                $"({((currentEvent.Assistant != null) ? currentEvent.Assistant.Name : "")})",

                Location = new Point(_leftMargin, _eventLabelPosition),
                AutoSize = true,
                Font = new Font("Arial", _fontSize)
            };

            _eventLabelPosition += _stepMargin;
            _eventsPanel.Controls.Add(eventLabel);

            eventLabel = new Label
            {
                Text = $"{currentEvent.Player.Team.Name}, " +
                $"#{currentEvent.Player.Number}, " +
                $"{currentEvent.Player.Position}, " +
                $"{currentEvent.Player.Nationality}",

                Location = new Point(_leftMargin, _eventLabelPosition),
                AutoSize = true,
                Font = new Font("Arial", _fontSize / 2)
            };

            _eventLabelPosition += _stepMargin;
            _eventsPanel.Controls.Add(eventLabel);
        }

        public void WriteStats(ICollection<T1> teams)
        {
            ICollection<T2> players = new List<T2>();
            IList<T2> sortedPlayers = new List<T2>();
            IList<int> values = new List<int>();

            foreach (var currentTeam in teams)
            {
                foreach (var currentPlayer in currentTeam.Players)
                {
                    players.Add((T2)currentPlayer);
                }
            }

            switch ((ProtocolForm<T1, T2>.StatsType)StatsInput.SelectedItem)
            {
                case (ProtocolForm<T1, T2>.StatsType.Goals):
                    {
                        sortedPlayers = players.OrderByDescending(currentPlayer =>
                        (currentPlayer as FootballPlayer).Goals).ToList();

                        foreach (var player in sortedPlayers)
                        {
                            values.Add((player as FootballPlayer).Goals);
                        }

                        break;
                    }
                case (ProtocolForm<T1, T2>.StatsType.Assists):
                    {
                        sortedPlayers = players.OrderByDescending(currentPlayer =>
                        (currentPlayer as FootballPlayer).Assists).ToList();

                        foreach (var player in sortedPlayers)
                        {
                            values.Add((player as FootballPlayer).Assists);
                        }

                        break;
                    }
                case (ProtocolForm<T1, T2>.StatsType.Yellow_cards):
                    {
                        sortedPlayers = players.OrderByDescending(currentPlayer =>
                        (currentPlayer as FootballPlayer).YellowCards).ToList();

                        foreach (var player in sortedPlayers)
                        {
                            values.Add((player as FootballPlayer).YellowCards);
                        }

                        break;
                    }
                case (ProtocolForm<T1, T2>.StatsType.Red_cards):
                    {
                        sortedPlayers = players.OrderByDescending(currentPlayer =>
                        (currentPlayer as FootballPlayer).RedCards).ToList();

                        foreach (var player in sortedPlayers)
                        {
                            values.Add((player as FootballPlayer).RedCards);
                        }

                        break;
                    }
                case (ProtocolForm<T1, T2>.StatsType.Points):
                    {
                        sortedPlayers = players.OrderByDescending(currentPlayer =>
                        (currentPlayer as BasketballPlayer).Points).ToList();
                        
                        foreach (var player in sortedPlayers)
                        {
                            values.Add((player as BasketballPlayer).Points);
                        }

                        break;
                    }
                case (ProtocolForm<T1, T2>.StatsType.Removals):
                    {
                        sortedPlayers = players.OrderByDescending(currentPlayer =>
                        (currentPlayer as BasketballPlayer).Removals).ToList();

                        foreach (var player in sortedPlayers)
                        {
                            values.Add((player as BasketballPlayer).Removals);
                        }

                        break;
                    }
                default:
                    break;
            }

            int count = 1;
            _eventsPanel.Controls.Clear();
            _eventLabelPosition = 20;

            for (var i = 0; i < sortedPlayers.Count; i++)
            {
                Label eventLabel = new Label
                {
                    Text = $"{count}.  {values[i]}  |  " +
                    $"{sortedPlayers[i].Name}, " +
                    $"({sortedPlayers[i].Team.Name}, " +
                    $"{sortedPlayers[i].Nationality}, " +
                    $"#{sortedPlayers[i].Number}, " +
                    $"{sortedPlayers[i].Position})",

                    Location = new Point(_leftMargin, _eventLabelPosition),
                    AutoSize = true,
                    Font = new Font("Arial", _fontSize - 2)
                };

                _eventLabelPosition += _stepMargin;
                _eventsPanel.Controls.Add(eventLabel);
                count++;
            }
        }

        private void EnableInput()
        {
            ProtocolInput.Enabled = false;
            StatsInput.Enabled = false;
            DateInput.Enabled = false;
            MinuteInput.Enabled = true;
            EventTypeInput.Enabled = true;
            PlayerInput.Enabled = true;
            _addEventButton.Enabled = true;
            _saveProtocolButton.Enabled = true;

            GameCreated = true;
            _eventsPanel.Controls.Clear();
            _eventLabelPosition = 20;
        }
    }
}
