using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    class UserInterface
    {
        public enum FootballEventType {
            [Description("Goal")] Goal,
            [Description("Yellow card")] YellowCard,
            [Description("Red card")] RedCard
        };

        public ComboBox HomeTeamInput { get; private set; }
        public ComboBox GuestTeamInput { get; private set; }
        public DateTimePicker DateInput { get; private set; }
        public NumericUpDown MinuteInput { get; private set; }
        public ComboBox EventTypeInput { get; private set; }
        public ComboBox PlayerInput { get; private set; }
        private Button _addEventButton;

        private IList<FootballTeamComboItem> _teamComboItems;
        private IList<FootballPlayerComboItem> _playerComboItems;
        private IList<FootballEventType> _eventComboItems;

        public Database CurrentDatabase { get; set; }

        public UserInterface(ComboBox newHomeTeamInput, ComboBox newGuestTeamInput,
            DateTimePicker newDateInput, NumericUpDown newMinuteInput,
            ComboBox newEventTypeInput, ComboBox newPlayerInput, Button newAddEventButton)
        {
            HomeTeamInput = newHomeTeamInput;
            GuestTeamInput = newGuestTeamInput;
            DateInput = newDateInput;
            MinuteInput = newMinuteInput;
            EventTypeInput = newEventTypeInput;
            PlayerInput = newPlayerInput;
            _addEventButton = newAddEventButton;

            _teamComboItems = new List<FootballTeamComboItem>();
            _playerComboItems = new List<FootballPlayerComboItem>();
            _eventComboItems = new List<FootballEventType>();

            AddEventTypeItems();
        }

        private void AddEventTypeItems()
        {
            foreach (FootballEventType type in (FootballEventType[])Enum.GetValues(typeof(FootballEventType)))
            {
                _eventComboItems.Add(type);
            }

            EventTypeInput.Items.AddRange(_eventComboItems.Cast<object>().ToArray());
        }

        public void AddTeamComboItem(FootballTeam currentTeam)
        {
            _teamComboItems.Add(new FootballTeamComboItem(currentTeam.Name, currentTeam));
        }

        public void AddTeamComboItemsToComboBox()
        {
            HomeTeamInput.Items.AddRange(_teamComboItems.Cast<object>().ToArray());
            GuestTeamInput.Items.AddRange(_teamComboItems.Cast<object>().ToArray());
        }

        public void OnTeamInputIndexChange(ComboBox thisTeamInput, ComboBox otherTeamInput)
        {
            thisTeamInput.Enabled = false;
            var selectedItem = (FootballTeamComboItem)thisTeamInput.SelectedItem;

            foreach (FootballPlayer player in selectedItem.Team.TeamPlayers)
            {
                _playerComboItems.Add(new FootballPlayerComboItem(player.Name, player));
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

        private void EnableInput()
        {
            DateInput.Enabled = false;
            MinuteInput.Enabled = true;
            EventTypeInput.Enabled = true;
            PlayerInput.Enabled = true;
            _addEventButton.Enabled = true;

            CurrentDatabase.InsertGame();
        }
    }
}
