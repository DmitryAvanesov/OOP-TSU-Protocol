﻿using System;
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
        public ComboBox GameInput { get; private set; }
        public ComboBox StatsInput { get; private set; }
        public ComboBox HomeTeamInput { get; private set; }
        public ComboBox GuestTeamInput { get; private set; }
        public DateTimePicker DateInput { get; private set; }
        public NumericUpDown MinuteInput { get; private set; }
        public ComboBox EventTypeInput { get; private set; }
        public ComboBox PlayerInput { get; private set; }
        public Label AssistantLabel { get; private set; }
        public ComboBox AssistantInput { get; private set; }
        private Button _addEventButton;
        private Button _saveProtocolButton;
        private Panel _eventsPanel;

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

        public UserInterface(ComboBox newGameInput, ComboBox newStatsInput,
            ComboBox newHomeTeamInput, ComboBox newGuestTeamInput, DateTimePicker newDateInput,
            NumericUpDown newMinuteInput, ComboBox newEventTypeInput, ComboBox newPlayerInput,
            Label newAssistantLabel, ComboBox newAssistantInput, Button newAddEventButton,
            Button newSaveProtocolButton, Panel newEventsPanel)
        {
            GameInput = newGameInput;
            StatsInput = newStatsInput;
            HomeTeamInput = newHomeTeamInput;
            GuestTeamInput = newGuestTeamInput;
            DateInput = newDateInput;
            MinuteInput = newMinuteInput;
            EventTypeInput = newEventTypeInput;
            PlayerInput = newPlayerInput;
            AssistantLabel = newAssistantLabel;
            AssistantInput = newAssistantInput;
            _addEventButton = newAddEventButton;
            _saveProtocolButton = newSaveProtocolButton;
            _eventsPanel = newEventsPanel;

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
        }

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

        public void AddGameComboItem(Game<T1, T2> currentGame)
        {
            _gameComboItems.Add(new ComboItem<Game<T1, T2>>(currentGame.Name, currentGame));
        }

        public void AddGameComboItemsToComboBox()
        {
            GameInput.Items.AddRange(_gameComboItems.Cast<object>().ToArray());
        }

        public void AddTeamComboItem(T1 currentTeam)
        {
            _teamComboItems.Add(new ComboItem<T1>(currentTeam.Name, currentTeam));
        }

        public void AddTeamComboItemsToComboBox()
        {
            HomeTeamInput.Items.AddRange(_teamComboItems.Cast<object>().ToArray());
            GuestTeamInput.Items.AddRange(_teamComboItems.Cast<object>().ToArray());
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
                ((ComboItem<Game<T1, T2>>)GameInput.SelectedItem).Object.Events)
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
                    $"#{sortedPlayers[i].Nationality}, " +
                    $"{sortedPlayers[i].Number}, " +
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
            GameInput.Enabled = false;
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
