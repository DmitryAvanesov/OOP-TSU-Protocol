using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using static OOP_TSU_Protocol.UserInterface;

namespace OOP_TSU_Protocol
{
    class Database
    {
        private UserInterface _userInterface;

        private static string _connectionString =
            "Server=localhost;Database=tsu-oop-protocol-db;Uid=root;Pwd=root;";
        private MySqlConnection _conDatabase = new MySqlConnection(_connectionString);
        MySqlDataReader reader;

        public Database(UserInterface newUserInterface)
        {
            _userInterface = newUserInterface;
        }

        public void InsertGame()
        {
            _conDatabase.Open();

            string query = $"INSERT INTO football_game VALUES" +
                $"(NULL," +
                $"'{_userInterface.DateInput.Value}'," +
                $"{((FootballTeamComboItem)_userInterface.HomeTeamInput.SelectedItem).Team.Id}," +
                $"{((FootballTeamComboItem)_userInterface.GuestTeamInput.SelectedItem).Team.Id});";
            var cmdDatabase = new MySqlCommand(query, _conDatabase);
            reader = cmdDatabase.ExecuteReader();

            _conDatabase.Close();
        }

        public void InsertEvent()
        {
            _conDatabase.Open();

            int currentGameId;
            string query = $"SELECT football_game_ID FROM football_game " +
                $"ORDER BY football_game_ID DESC LIMIT 1;";
            var cmdDatabase = new MySqlCommand(query, _conDatabase);
            currentGameId = int.Parse(cmdDatabase.ExecuteScalar().ToString());
            Console.WriteLine(currentGameId);

            query = $"INSERT INTO event VALUES" +
                $"({currentGameId}," +
                $"{decimal.ToInt32(_userInterface.MinuteInput.Value)}," +
                $"'{((FootballEventType)_userInterface.EventTypeInput.SelectedItem).ToString()}'," +
                $"{((FootballPlayerComboItem)_userInterface.PlayerInput.SelectedItem).Player.Id});";
            cmdDatabase = new MySqlCommand(query, _conDatabase);
            reader = cmdDatabase.ExecuteReader();

            _conDatabase.Close();
        }
    }
}
