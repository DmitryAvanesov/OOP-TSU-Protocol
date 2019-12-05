using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace OOP_TSU_Protocol
{
    public class Database<T1, T2>
        where T1 : Team, new()
        where T2 : Player
    {
        private UserInterface<T1, T2> _userInterface;

        private static string _connectionString =
            "Server=localhost;Database=tsu-oop-protocol-db;Uid=root;Pwd=root;";
        private MySqlConnection _conDatabase = new MySqlConnection(_connectionString);
        private MySqlDataReader _reader;

        public Database(UserInterface<T1, T2> newUserInterface)
        {
            _userInterface = newUserInterface;
        }

        public List<List<string>> SelectTeams()
        {
            _conDatabase.Open();

            string query = $"SELECT * FROM team WHERE sport = {Team.SportId}";
            MySqlCommand command = new MySqlCommand(query, _conDatabase);
            _reader = command.ExecuteReader();

            var teamData = new List<List<string>>();
            int currentTeam = 0;

            while (_reader.Read())
            {
                teamData.Add(new List<string>());

                for (int i = 0; i < _reader.FieldCount; i++)
                {
                    teamData[currentTeam].Add(_reader[i].ToString());
                }

                currentTeam++;
            }

            _conDatabase.Close();
            return teamData;
        }

        public List<List<string>> SelectPlayers(int team)
        {
            _conDatabase.Open();

            string query = $"SELECT * FROM player WHERE sport = {Team.SportId} AND team = {team}";
            MySqlCommand command = new MySqlCommand(query, _conDatabase);
            _reader = command.ExecuteReader();

            var playerData = new List<List<string>>();
            int currentPlayer = 0;

            while (_reader.Read())
            {
                playerData.Add(new List<string>());

                for (int i = 0; i < _reader.FieldCount; i++)
                {
                    playerData[currentPlayer].Add(_reader[i].ToString());
                }

                currentPlayer++;
            }

            _conDatabase.Close();
            return playerData;
        }

        public void InsertGame()
        {
            _conDatabase.Open();

            string query = $"INSERT INTO game VALUES" +
                $"(NULL," +
                $"{Team.SportId}," +
                $"'{_userInterface.DateInput.Value}'," +
                $"{((ComboItem<T1>)_userInterface.HomeTeamInput.SelectedItem).Object.Id}," +
                $"{((ComboItem<T1>)_userInterface.GuestTeamInput.SelectedItem).Object.Id});";
            var cmdDatabase = new MySqlCommand(query, _conDatabase);
            _reader = cmdDatabase.ExecuteReader();

            _conDatabase.Close();
        }

        public void InsertEvent()
        {
            _conDatabase.Open();

            int currentGameId;
            string query = $"SELECT game_ID FROM game " +
                $"ORDER BY game_ID DESC LIMIT 1;";
            var cmdDatabase = new MySqlCommand(query, _conDatabase);
            currentGameId = int.Parse(cmdDatabase.ExecuteScalar().ToString());
            Console.WriteLine(currentGameId);

            query = $"INSERT INTO event VALUES" +
                $"({currentGameId}," +
                $"{decimal.ToInt32(_userInterface.MinuteInput.Value)}," +
                $"'{_userInterface.EventTypeInput.SelectedItem.ToString()}'," +
                $"{((ComboItem<T2>)_userInterface.PlayerInput.SelectedItem).Object.Id});";
            cmdDatabase = new MySqlCommand(query, _conDatabase);
            _reader = cmdDatabase.ExecuteReader();

            _conDatabase.Close();
        }
    }
}
