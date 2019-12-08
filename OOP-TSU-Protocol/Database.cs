using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace OOP_TSU_Protocol
{
    public class Database<T1, T2>
        where T1 : Team, new()
        where T2 : Player, new()
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

        public List<List<string>> SelectGames()
        {
            _conDatabase.Open();

            string query = $"SELECT * FROM game WHERE sport = {Team.SportId}";
            MySqlCommand command = new MySqlCommand(query, _conDatabase);
            _reader = command.ExecuteReader();

            var gameData = new List<List<string>>();
            int currentGame = 0;

            while (_reader.Read())
            {
                gameData.Add(new List<string>());

                for (int i = 0; i < _reader.FieldCount; i++)
                {
                    gameData[currentGame].Add(_reader[i].ToString());
                }

                currentGame++;
            }

            _conDatabase.Close();
            return gameData;
        }

        public List<List<string>> SelectEvents(Game<T1, T2> game)
        {
            _conDatabase.Open();

            string query = $"SELECT * FROM event WHERE game = {game.Id}";
            MySqlCommand command = new MySqlCommand(query, _conDatabase);
            _reader = command.ExecuteReader();

            var eventData = new List<List<string>>();
            int currentEvent = 0;

            while (_reader.Read())
            {
                eventData.Add(new List<string>());

                for (int i = 0; i < _reader.FieldCount; i++)
                {
                    eventData[currentEvent].Add(_reader[i].ToString());
                }

                currentEvent++;
            }

            _conDatabase.Close();
            return eventData;
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

        public void InsertGame(Game<T1, T2> currentGame)
        {
            _conDatabase.Open();

            string query = $"INSERT INTO game VALUES" +
                $"(NULL," +
                $"{Team.SportId}," +
                $"'{currentGame.Date}'," +
                $"{currentGame.HomeTeam.Id}," +
                $"{currentGame.GuestTeam.Id}," +
                $"{currentGame.HomeTeamScore}," +
                $"{currentGame.GuestTeamScore});";

            var cmdDatabase = new MySqlCommand(query, _conDatabase);
            _reader = cmdDatabase.ExecuteReader();

            _conDatabase.Close();
        }

        public void InsertEvent(Event<T1, T2> currentEvent)
        {
            _conDatabase.Open();

            int currentGameId;
            string assistant;

            string query = $"SELECT game_ID FROM game " +
                $"ORDER BY game_ID DESC LIMIT 1;";
            var cmdDatabase = new MySqlCommand(query, _conDatabase);
            currentGameId = int.Parse(cmdDatabase.ExecuteScalar().ToString());

            assistant = currentEvent.Assistant != null ?
                currentEvent.Assistant.Id.ToString() :
                "null";

            query = $"INSERT INTO event VALUES" +
                $"({currentGameId}," +
                $"{currentEvent.Minute}," +
                $"'{currentEvent.Type}'," +
                $"{currentEvent.Player.Id}," +
                $"{assistant});";

            cmdDatabase = new MySqlCommand(query, _conDatabase);
            _reader = cmdDatabase.ExecuteReader();

            _conDatabase.Close();
        }
    }
}
