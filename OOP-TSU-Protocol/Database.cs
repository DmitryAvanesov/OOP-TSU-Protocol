using MySql.Data.MySqlClient;
using System;

namespace OOP_TSU_Protocol
{
    class Database<T1, T2>
        where T1 : Team
        where T2 : Player
    {
        private UserInterface<T1, T2> _userInterface;

        private static string _connectionString =
            "Server=localhost;Database=tsu-oop-protocol-db;Uid=root;Pwd=root;";
        private MySqlConnection _conDatabase = new MySqlConnection(_connectionString);
        MySqlDataReader reader;

        public Database(UserInterface<T1, T2> newUserInterface)
        {
            _userInterface = newUserInterface;
        }

        public void InsertGame()
        {
            _conDatabase.Open();

            string query = $"INSERT INTO football_game VALUES" +
                $"(NULL," +
                $"'{_userInterface.DateInput.Value}'," +
                $"{((ComboItem<T1>)_userInterface.HomeTeamInput.SelectedItem).Object.Id}," +
                $"{((ComboItem<T1>)_userInterface.GuestTeamInput.SelectedItem).Object.Id});";
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
                $"'{_userInterface.EventTypeInput.SelectedItem.ToString()}'," +
                $"{((ComboItem<T2>)_userInterface.PlayerInput.SelectedItem).Object.Id});";
            cmdDatabase = new MySqlCommand(query, _conDatabase);
            reader = cmdDatabase.ExecuteReader();

            _conDatabase.Close();
        }
    }
}
