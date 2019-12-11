using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    public partial class ProtocolForm<T1, T2> : Form
        where T1 : Team, new()
        where T2 : Player, new()
    {
        private MainForm _mainForm;

        private UserInterface<T1, T2> _userInterface;
        private Database<T1, T2> _database;
        private ICollection<T1> _teams;
        private ICollection<Game<T1, T2>> _games;
        private Game<T1, T2> _activeGame;

        public enum EventType
        {
            Goal,
            Yellow_card,
            Red_card,
            Two_points_shot,
            Three_points_shot,
            Removal
        };
        private Dictionary<EventType, Type> _eventTypes;

        public enum StatsType
        {
            Goals,
            Assists,
            Yellow_cards,
            Red_cards,
            Points,
            Removals
        };
        private Dictionary<StatsType, Type> _statsTypes;

        public ProtocolForm(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;

            _userInterface = new UserInterface<T1, T2>(GameInput, StatsInput, HomeTeamInput,
                GuestTeamInput, MinuteInput, EventTypeInput, PlayerInput, AssistantLabel,
                AssistantInput, AddEventButton, SaveProtocolButton, BackButton, EventsPanel);
            _database = new Database<T1, T2>(_userInterface);
            _userInterface.CurrentDatabase = _database;
            _games = new List<Game<T1, T2>>();
            _teams = new List<T1>();

            _eventTypes = new Dictionary<EventType, Type>
            {
                { EventType.Goal, typeof(FootballPlayer) },
                { EventType.Yellow_card, typeof(FootballPlayer) },
                { EventType.Red_card, typeof(FootballPlayer) },
                { EventType.Two_points_shot, typeof(BasketballPlayer) },
                { EventType.Three_points_shot, typeof(BasketballPlayer) },
                { EventType.Removal, typeof(BasketballPlayer) }
            };

            _statsTypes = new Dictionary<StatsType, Type>
            {
                { StatsType.Goals, typeof(FootballPlayer) },
                { StatsType.Assists, typeof(FootballPlayer) },
                { StatsType.Yellow_cards, typeof(FootballPlayer) },
                { StatsType.Red_cards, typeof(FootballPlayer) },
                { StatsType.Points, typeof(BasketballPlayer) },
                { StatsType.Removals, typeof(BasketballPlayer) }
            };

            AddTeams();
            AddGames();
            _userInterface.AddEventTypeItems(_eventTypes);
            _userInterface.AddStatsTypeItems(_statsTypes);
        }

        private void AddGames()
        {
            Game<T1, T2> currentGame;
            int currentId;
            DateTime currentDate;
            T1 currentHomeTeam = new T1();
            T1 currentGuestTeam = new T1();
            int currentHomeTeamScore;
            int currentGuestTeamScore;

            var data = _database.SelectGames();

            foreach (var currentGameData in data)
            {
                currentId = int.Parse(currentGameData[0]);
                currentDate = Convert.ToDateTime(currentGameData[2]);

                foreach (var team in _teams)
                {
                    if (team.Id == int.Parse(currentGameData[3]))
                    {
                        currentHomeTeam = team;
                    }

                    if (team.Id == int.Parse(currentGameData[4]))
                    {
                        currentGuestTeam = team;
                    }
                }

                currentHomeTeamScore = int.Parse(currentGameData[5]);
                currentGuestTeamScore = int.Parse(currentGameData[6]);

                currentGame = new Game<T1, T2>(currentId, currentDate, currentHomeTeam,
                    currentGuestTeam, currentHomeTeamScore, currentGuestTeamScore);
                AddEvents(currentGame);
                
                _games.Add(currentGame);
                _userInterface.AddGameComboItem(currentGame);
            }

            _userInterface.AddGameComboItemsToComboBox();
        }

        private void AddEvents(Game<T1, T2> currentGame)
        {
            Event<T1, T2> currentEvent;
            int currentMinute;
            T2 currentPlayer = new T2();
            T2 currentAssistant = null;

            var data = _database.SelectEvents(currentGame);

            foreach (var currentEventData in data)
            {
                currentMinute = int.Parse(currentEventData[1]);
                EventType currentType = (EventType)Enum.Parse
                    (typeof(EventType), currentEventData[2], true);

                foreach (var player in currentGame.HomeTeam.Players)
                {
                    if (player.Id == int.Parse(currentEventData[3]))
                    {
                        currentPlayer = (T2)player;
                    }

                    if (player.Id == (int.TryParse(currentEventData[4], out int result) ?
                        int.Parse(currentEventData[4]) : (int?)null))
                    {
                        currentAssistant = (T2)player;
                    }
                }

                foreach (var player in currentGame.GuestTeam.Players)
                {
                    if (player.Id == int.Parse(currentEventData[3]))
                    {
                        currentPlayer = (T2)player;
                    }

                    if (player.Id == (int.TryParse(currentEventData[4], out int result) ?
                         int.Parse(currentEventData[4]) : (int?)null))
                    {
                        currentAssistant = (T2)player;
                    }
                }

                currentEvent = new Event<T1, T2>(currentGame, currentMinute, currentType,
                    currentPlayer, currentAssistant);
                currentGame.Events.Add(currentEvent);
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

        private void GameInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.OnGameInputIndexChanged();
        }

        private void StatsInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.WriteStats(_teams);
        }

        private void HomeTeamInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.OnTeamInputIndexChange(HomeTeamInput, GuestTeamInput);

            if (_userInterface.GameCreated)
            {
                InitializeGame();
            }
        }

        private void GuestTeamInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.OnTeamInputIndexChange(GuestTeamInput, HomeTeamInput);

            if (_userInterface.GameCreated)
            {
                InitializeGame();
            }
        }

        private void InitializeGame()
        {
            _activeGame = new Game<T1, T2>(0, DateInput.Value,
                ((ComboItem<T1>)HomeTeamInput.SelectedItem).Object,
                ((ComboItem<T1>)GuestTeamInput.SelectedItem).Object);
        }

        private void EventTypeInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.OnEventTypeInputIndexChange();
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            if (_userInterface.EventTypeInput.SelectedItem != null &&
                _userInterface.PlayerInput.SelectedItem != null)
            {
                _activeGame.AddEvent(_activeGame, int.Parse(MinuteInput.Value.ToString()),
                (EventType)EventTypeInput.SelectedItem,
                ((ComboItem<T2>)PlayerInput.SelectedItem).Object,
                (AssistantInput.SelectedItem != null) ?
                ((ComboItem<T2>)AssistantInput.SelectedItem).Object :
                null);

                _userInterface.WriteEvent(_activeGame.Events.ToArray()[_activeGame.Events.Count - 1]);
                var player = ((ComboItem<T2>)PlayerInput.SelectedItem).Object;

                if ((EventType)EventTypeInput.SelectedItem == EventType.Goal)
                {
                    player.IncreaseScore();
                    if (AssistantInput.SelectedItem != null)
                    {
                        (((ComboItem<T2>)AssistantInput.SelectedItem).Object
                        as FootballPlayer).AddAssist();
                    }
                    _activeGame.IncreaseScore((T1)player.Team);
                }
                else if ((EventType)EventTypeInput.SelectedItem == EventType.Yellow_card)
                {
                    (player as FootballPlayer).GetYellowCard();
                }
                else if ((EventType)EventTypeInput.SelectedItem == EventType.Red_card)
                {
                    (player as FootballPlayer).GetRedCard();
                }
                else if ((EventType)EventTypeInput.SelectedItem == EventType.Two_points_shot)
                {
                    player.IncreaseScore(2);
                    _activeGame.IncreaseScore((T1)player.Team, 2);
                }
                else if ((EventType)EventTypeInput.SelectedItem == EventType.Three_points_shot)
                {
                    player.IncreaseScore(3);
                    _activeGame.IncreaseScore((T1)player.Team, 3);
                }
                else if ((EventType)EventTypeInput.SelectedItem == EventType.Removal)
                {
                    (player as BasketballPlayer).GetRemoval();
                }
            }
            else
            {
                MessageBox.Show("Fill in all the blanks");
            }
        }

        private void SaveProtocolButton_Click(object sender, EventArgs e)
        {
            _database.InsertGame(_activeGame);

            foreach (var currentEvent in _activeGame.Events)
            {
                _database.InsertEvent(currentEvent);
            }

            _database.UpdateData();

            Hide();
            _mainForm.Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Hide();
            _mainForm.Show();
        }
    }
}