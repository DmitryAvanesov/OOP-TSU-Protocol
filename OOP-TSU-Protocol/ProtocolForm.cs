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
        private ManagementForm<T1, T2> _managementForm;

        private UserInterface<T1, T2> _userInterface;
        private Database<T1, T2> _database;
        private Tournament<T1, T2> _tournament;

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

        public ProtocolForm(ManagementForm<T1, T2> managementForm, Tournament<T1, T2> newTournament)
        {
            InitializeComponent();

            _managementForm = managementForm;

            _userInterface = new UserInterface<T1, T2>(ProtocolInput, StatsInput,
                GameInput, MinuteInput, EventTypeInput, PlayerInput, AssistantLabel,
                AssistantInput, AddEventButton, SaveProtocolButton, BackButton, EventsPanel);
            _database = new Database<T1, T2>(_userInterface);
            _userInterface.CurrentDatabase = _database;
            _tournament = newTournament;

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

            AddProtocols();
            AddGames();
            _userInterface.AddEventTypeItems(_eventTypes);
            _userInterface.AddStatsTypeItems(_statsTypes);
        }

        private void AddProtocols()
        {
            foreach (var currentGame in _tournament.Games)
            {
                if (currentGame.Played == 1)
                {
                    AddEvents(currentGame);
                    _userInterface.AddProtocolComboItem(currentGame);
                }
            }

            _userInterface.AddProtocolComboItemsToComboBox();
        }

        private void AddEvents(Game<T1, T2> currentGame)
        {
            currentGame.Events.Clear();

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

        private void AddGames()
        {
            foreach (var game in _tournament.Games)
            {
                if (game.Played == 0)
                {
                    _userInterface.AddGameComboItem(game);
                }
            }

            _userInterface.AddGameComboItemsToComboBox();
        }

        private void EventTypeInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.OnEventTypeInputIndexChange();
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            Game<T1, T2> activeGame =
                ((ComboItem<Game<T1, T2>>)_userInterface.GameInput.SelectedItem).Object;

            if (_userInterface.EventTypeInput.SelectedItem != null &&
                _userInterface.PlayerInput.SelectedItem != null)
            {
                activeGame.AddEvent(activeGame, int.Parse(MinuteInput.Value.ToString()),
                (EventType)EventTypeInput.SelectedItem,
                ((ComboItem<T2>)PlayerInput.SelectedItem).Object,
                (AssistantInput.SelectedItem != null) ?
                ((ComboItem<T2>)AssistantInput.SelectedItem).Object :
                null);

                _userInterface.WriteEvent(activeGame.Events.ToArray()[activeGame.Events.Count - 1]);
                var player = ((ComboItem<T2>)PlayerInput.SelectedItem).Object;

                if ((EventType)EventTypeInput.SelectedItem == EventType.Goal)
                {
                    player.IncreaseScore();
                    if (AssistantInput.SelectedItem != null)
                    {
                        (((ComboItem<T2>)AssistantInput.SelectedItem).Object
                        as FootballPlayer).AddAssist();
                    }
                    activeGame.IncreaseScore((T1)player.Team);
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
                    activeGame.IncreaseScore((T1)player.Team, 2);
                }
                else if ((EventType)EventTypeInput.SelectedItem == EventType.Three_points_shot)
                {
                    player.IncreaseScore(3);
                    activeGame.IncreaseScore((T1)player.Team, 3);
                }
                else if ((EventType)EventTypeInput.SelectedItem == EventType.Removal)
                {
                    (player as BasketballPlayer).GetRemoval();
                }

                activeGame.DistributePoints();
            }
            else
            {
                MessageBox.Show("Fill in all the blanks");
            }
        }

        private void SaveProtocolButton_Click(object sender, EventArgs e)
        {
            Game<T1, T2> activeGame =
                ((ComboItem<Game<T1, T2>>)_userInterface.GameInput.SelectedItem).Object;

            activeGame.Played = 1;
            _database.UpdateGameData(activeGame);

            foreach (var currentEvent in activeGame.Events)
            {
                _database.InsertEvent(currentEvent, activeGame);
            }

            _database.UpdateData();

            Hide();
            _managementForm.MainForm.Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Hide();
            _managementForm.Show();
        }

        private void StatsInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.WriteStats(_tournament.Teams);
        }

        private void GameInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.OnGameInputIndexChange();
        }

        private void ProtocolInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.OnProtocolInputIndexChanged();
        }

        private void TableButton_Click(object sender, EventArgs e)
        {
            _userInterface.WriteTable(_tournament.Teams);
        }
    }
}