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
        public ComboBox HomeTeamInput { get; private set; }
        public ComboBox GuestTeamInput { get; private set; }
        public DateTimePicker DateInput { get; private set; }
        public NumericUpDown MinuteInput { get; private set; }
        public ComboBox EventTypeInput { get; private set; }
        public ComboBox PlayerInput { get; private set; }
        private Button _addEventButton;
        private Button _saveProtocolButton;
        private Panel _eventsPanel;

        private ICollection<ComboItem<T1>> _teamComboItems;
        private ICollection<ComboItem<T2>> _playerComboItems;
        private ICollection<ProtocolForm<T1, T2>.EventType> _eventComboItems;

        public Database<T1, T2> CurrentDatabase { get; set; }
        public bool GameCreated { get; private set; }
        private int _eventLabelPosition;
        private int _leftMargin;
        private int _stepMargin;
        private int _fontSize;

        public UserInterface(ComboBox newHomeTeamInput, ComboBox newGuestTeamInput,
            DateTimePicker newDateInput, NumericUpDown newMinuteInput,
            ComboBox newEventTypeInput, ComboBox newPlayerInput,
            Button newAddEventButton, Button newSaveProtocolButton, Panel newEventsPanel)
        {
            HomeTeamInput = newHomeTeamInput;
            GuestTeamInput = newGuestTeamInput;
            DateInput = newDateInput;
            MinuteInput = newMinuteInput;
            EventTypeInput = newEventTypeInput;
            PlayerInput = newPlayerInput;
            _addEventButton = newAddEventButton;
            _saveProtocolButton = newSaveProtocolButton;
            _eventsPanel = newEventsPanel;

            _teamComboItems = new List<ComboItem<T1>>();
            _playerComboItems = new List<ComboItem<T2>>();
            _eventComboItems = new List<ProtocolForm<T1, T2>.EventType>();

            GameCreated = false;
            _eventLabelPosition = 20;
            _leftMargin = 20;
            _stepMargin = 50;
            _fontSize = 16;

            AddEventTypeItems();
        }

        private void AddEventTypeItems()
        {
            foreach (ProtocolForm<T1, T2>.EventType type in
                Enum.GetValues(typeof(ProtocolForm<T1, T2>.EventType)))
            {
                _eventComboItems.Add(type);
            }

            EventTypeInput.Items.AddRange(_eventComboItems.Cast<object>().ToArray());
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

        public void AddPlayerComboItemsToComboBox()
        {
            PlayerInput.Items.AddRange(_playerComboItems.Cast<object>().ToArray());
            _playerComboItems.Clear();
        }

        public void OnTeamInputIndexChange(ComboBox thisTeamInput, ComboBox otherTeamInput)
        {
            thisTeamInput.Enabled = false;
            var selectedItem = (ComboItem<T1>)thisTeamInput.SelectedItem;

            foreach (T2 player in selectedItem.Object.TeamPlayers)
            {
                _playerComboItems.Add(new ComboItem<T2>(player.Name, player));
            }

            PlayerInput.Items.AddRange(_playerComboItems.Cast<object>().ToArray());
            _playerComboItems.Clear();

            if (!otherTeamInput.Enabled)
            {
                EnableInput();
            }
            else
            {
                otherTeamInput.Items.Remove(thisTeamInput.SelectedItem);
            }
        }

        public void WriteEvent(Event<T1, T2> currentEvent)
        {
            Label eventLabel = new Label
            {
                Text = $"{currentEvent.Minute}'  |  " +
                $"{currentEvent.Type.ToString()}  |  " +
                $"{currentEvent.Player.Name}",

                Location = new Point(_leftMargin, _eventLabelPosition),
                AutoSize = true,
                Font = new Font("Arial", _fontSize)
            };

            _eventLabelPosition += _stepMargin;
            _eventsPanel.Controls.Add(eventLabel);
        }

        private void EnableInput()
        {
            DateInput.Enabled = false;
            MinuteInput.Enabled = true;
            EventTypeInput.Enabled = true;
            PlayerInput.Enabled = true;
            _addEventButton.Enabled = true;
            _saveProtocolButton.Enabled = true;

            GameCreated = true;
        }
    }
}
