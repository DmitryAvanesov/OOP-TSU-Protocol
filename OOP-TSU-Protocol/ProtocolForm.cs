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
        private UserInterface<T1, T2> _userInterface;
        private Database<T1, T2> _database;
        private ICollection<T1> _teams;
        private Game<T1, T2> _game;

        public enum EventType
        {
            Goal,
            Yellow_card,
            Red_card
        };

        public ProtocolForm()
        {
            InitializeComponent();

            _userInterface = new UserInterface<T1, T2>(HomeTeamInput, GuestTeamInput,
                DateInput, MinuteInput, EventTypeInput, PlayerInput, AddEventButton,
                SaveProtocolButton, EventsPanel);
            _database = new Database<T1, T2>(_userInterface);
            _userInterface.CurrentDatabase = _database;
            _teams = new List<T1>();

            AddTeams();
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
            _game = new Game<T1, T2>(DateInput.Value,
                ((ComboItem<T1>)HomeTeamInput.SelectedItem).Object,
                ((ComboItem<T1>)GuestTeamInput.SelectedItem).Object);
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            _game.AddEvent(_game, int.Parse(MinuteInput.Value.ToString()),
                (EventType)EventTypeInput.SelectedItem,
                ((ComboItem<T2>)PlayerInput.SelectedItem).Object);

            _userInterface.WriteEvent(_game.Events.ToArray()[_game.Events.Count - 1]);

            if ((EventType)EventTypeInput.SelectedItem == 0)
            {
                var player = ((ComboItem<T2>)PlayerInput.SelectedItem).Object;
              
                player.Score();
                _game.IncreaseScore((T1)player.Team);
            }
        }

        private void SaveProtocolButton_Click(object sender, EventArgs e)
        {
            _database.InsertGame(_game);

            foreach (var currentEvent in _game.Events)
            {
                _database.InsertEvent(currentEvent);
            }
        }
    }
}