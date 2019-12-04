using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OOP_TSU_Protocol
{
    public partial class ProtocolForm<T1, T2> : Form
        where T1 : Team
        where T2 : Player
    {
        private UserInterface<T1, T2> _userInterface;
        private Database<T1, T2> _database;
        private ICollection<T1> _teams;

        public ProtocolForm()
        {
            InitializeComponent();

            _userInterface = new UserInterface<T1, T2>(HomeTeamInput, GuestTeamInput, DateInput,
                MinuteInput, EventTypeInput, PlayerInput, AddEventButton);
            _database = new Database<T1, T2>(_userInterface);
            _userInterface.CurrentDatabase = _database;
            _teams = new List<T1>();

            AddTeams();
        }

        private void AddTeams()
        {
            T1 currentTeam;

            

            _userInterface.AddTeamComboItemsToComboBox();
        }

        private void HomeTeamInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.OnTeamInputIndexChange(HomeTeamInput, GuestTeamInput);
        }

        private void GuestTeamInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            _userInterface.OnTeamInputIndexChange(GuestTeamInput, HomeTeamInput);
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            _database.InsertEvent();
        }
    }
}