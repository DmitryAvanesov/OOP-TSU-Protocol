using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    class UserInterface
    {
        ComboBox homeTeamInput;
        ComboBox guestTeamInput;
        DateTimePicker dateInput;
        NumericUpDown minuteInput;
        ComboBox eventTypeInput;
        ComboBox playerInput;

        private IList<FootballTeamComboItem> _teamComboItems;
        private IList<FootballPlayerComboItem> _playerComboItems;

        public UserInterface(ComboBox newHomeTeamInput, ComboBox newGuestTeamInput, DateTimePicker newDateInput,
        NumericUpDown newMinuteInput, ComboBox newEventTypeInput, ComboBox newPlayerInput)
        {
            homeTeamInput = newHomeTeamInput;
            guestTeamInput = newGuestTeamInput;
            dateInput = newDateInput;
            minuteInput = newMinuteInput;
            eventTypeInput = newEventTypeInput;
            playerInput = newPlayerInput;

            _teamComboItems = new List<FootballTeamComboItem>();
            _playerComboItems = new List<FootballPlayerComboItem>();
        }

        public void AddComboItem(FootballTeam currentTeam)
        {
            _teamComboItems.Add(new FootballTeamComboItem(currentTeam.Name, currentTeam));
        }

        public void AddComboItemsToComboBox()
        {
            homeTeamInput.Items.AddRange(_teamComboItems.Cast<object>().ToArray());
            guestTeamInput.Items.AddRange(_teamComboItems.Cast<object>().ToArray());
        }

        public void OnTeamInputIndexChange(ComboBox thisTeamInput, ComboBox otherTeamInput)
        {
            thisTeamInput.Enabled = false;
            var selectedItem = (FootballTeamComboItem)thisTeamInput.SelectedItem;

            foreach (FootballPlayer player in selectedItem.Team.TeamPlayers)
            {
                _playerComboItems.Add(new FootballPlayerComboItem(player.Name, player));
            }

            playerInput.Items.AddRange(_playerComboItems.Cast<object>().ToArray());
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
            dateInput.Enabled = true;
            minuteInput.Enabled = true;
            eventTypeInput.Enabled = true;
            playerInput.Enabled = true;
        }
    }
}
