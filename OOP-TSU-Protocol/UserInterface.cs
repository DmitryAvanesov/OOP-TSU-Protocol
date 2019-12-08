using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private ICollection<ComboItem<T1>> _teamComboItems;
        private ICollection<ComboItem<T2>> _playerComboItems;
        private ICollection<ProtocolForm<T1, T2>.EventType> _eventComboItems;

        public Database<T1, T2> CurrentDatabase { get; set; }
        public bool GameCreated { get; private set; }
        private int _eventLabelPosition;
        private int _leftMargin;
        private int _stepMargin;
        private int _fontSize;

        public UserInterface(ComboBox newGameInput, ComboBox newHomeTeamInput,
            ComboBox newGuestTeamInput, DateTimePicker newDateInput, NumericUpDown newMinuteInput,
            ComboBox newEventTypeInput, ComboBox newPlayerInput, Label newAssistantLabel,
            ComboBox newAssistantInput, Button newAddEventButton, Button newSaveProtocolButton,
            Panel newEventsPanel)
        {
            GameInput = newGameInput;
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
            _teamComboItems = new List<ComboItem<T1>>();
            _playerComboItems = new List<ComboItem<T2>>();
            _eventComboItems = new List<ProtocolForm<T1, T2>.EventType>();

            GameCreated = false;
            _eventLabelPosition = 20;
            _leftMargin = 20;
            _stepMargin = 50;
            _fontSize = 16;
        }

        public void AddEventTypeItems(Dictionary<ProtocolForm<T1, T2>.EventType, Type> eventTypes)
        {
            foreach (KeyValuePair<ProtocolForm<T1, T2>.EventType, Type> type in eventTypes)
            {
                if (type.Value == typeof(T1))
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

            foreach (T2 player in selectedItem.Object.TeamPlayers)
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

        private void EnableInput()
        {
            GameInput.Enabled = false;
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
