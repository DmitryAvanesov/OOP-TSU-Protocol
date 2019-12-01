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

        private ComboBox _homeTeamInput;
        private ComboBox _guestTeamInput;
        private DateTimePicker _dateInput;
        private NumericUpDown _minuteInput;
        private ComboBox _eventTypeInput;
        private ComboBox _playerInput;

        private IList<FootballTeamComboItem> _teamComboItems;
        private IList<FootballPlayerComboItem> _playerComboItems;
        private IList<FootballEventType> _eventComboItems;

        public UserInterface(ComboBox newHomeTeamInput, ComboBox newGuestTeamInput, DateTimePicker newDateInput,
        NumericUpDown newMinuteInput, ComboBox newEventTypeInput, ComboBox newPlayerInput)
        {
            _homeTeamInput = newHomeTeamInput;
            _guestTeamInput = newGuestTeamInput;
            _dateInput = newDateInput;
            _minuteInput = newMinuteInput;
            _eventTypeInput = newEventTypeInput;
            _playerInput = newPlayerInput;

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

            _eventTypeInput.Items.AddRange(_eventComboItems.Cast<object>().ToArray());
        }

        public void AddTeamComboItem(FootballTeam currentTeam)
        {
            _teamComboItems.Add(new FootballTeamComboItem(currentTeam.Name, currentTeam));
        }

        public void AddTeamComboItemsToComboBox()
        {
            _homeTeamInput.Items.AddRange(_teamComboItems.Cast<object>().ToArray());
            _guestTeamInput.Items.AddRange(_teamComboItems.Cast<object>().ToArray());
        }

        public void OnTeamInputIndexChange(ComboBox thisTeamInput, ComboBox otherTeamInput)
        {
            thisTeamInput.Enabled = false;
            var selectedItem = (FootballTeamComboItem)thisTeamInput.SelectedItem;

            foreach (FootballPlayer player in selectedItem.Team.TeamPlayers)
            {
                _playerComboItems.Add(new FootballPlayerComboItem(player.Name, player));
            }

            _playerInput.Items.AddRange(_playerComboItems.Cast<object>().ToArray());
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
            _dateInput.Enabled = true;
            _minuteInput.Enabled = true;
            _eventTypeInput.Enabled = true;
            _playerInput.Enabled = true;
        }
    }
}
