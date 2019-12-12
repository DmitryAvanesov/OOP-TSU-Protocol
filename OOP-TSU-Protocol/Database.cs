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

        private int _sportId;

        public Database(UserInterface<T1, T2> newUserInterface)
        {
            _userInterface = newUserInterface;

            if (typeof(T1) == typeof(FootballTeam))
            {
                _sportId = 1;
            }
            else if (typeof(T1) == typeof(BasketballTeam))
            {
                _sportId = 2;
            }
        }

        public List<List<string>> SelectTournaments()
        {
            _conDatabase.Open();

            string query = $"SELECT * FROM tournament WHERE sport = {_sportId}";
            MySqlCommand command = new MySqlCommand(query, _conDatabase);
            _reader = command.ExecuteReader();

            var tournamentData = new List<List<string>>();
            int currentTournament = 0;

            while (_reader.Read())
            {
                tournamentData.Add(new List<string>());

                for (int i = 0; i < _reader.FieldCount; i++)
                {
                    tournamentData[currentTournament].Add(_reader[i].ToString());
                }

                currentTournament++;
            }

            _reader.Close();
            _conDatabase.Close();
            return tournamentData;
        }

        public List<List<string>> SelectGamesToTournament(int tournamentId)
        {
            _conDatabase.Open();

            string query = $"SELECT * FROM game WHERE tournament = {tournamentId}";
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

            _reader.Close();
            _conDatabase.Close();
            return gameData;
        }

        public List<List<string>> SelectTeamsToTournament(int tournamentId)
        {
            _conDatabase.Open();

            string query = $"SELECT DISTINCT * FROM team WHERE team_ID IN" +
                $"(SELECT team FROM tournament_team WHERE tournament = {tournamentId})";
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

            _reader.Close();
            _conDatabase.Close();
            return teamData;
        }

        public List<List<string>> SelectGames()
        {
            _conDatabase.Open();

            string query = $"SELECT * FROM game WHERE sport = {_sportId}";
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

            _reader.Close();
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

            _reader.Close();
            _conDatabase.Close();
            return eventData;
        }

        public List<List<string>> SelectTeams()
        {
            _conDatabase.Open();

            string query = $"SELECT * FROM team WHERE sport = {_sportId}";
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

            _reader.Close();
            _conDatabase.Close();
            return teamData;
        }

        public List<List<string>> SelectPlayers(int team)
        {
            _conDatabase.Open();

            string query = $"SELECT * FROM player WHERE sport = {_sportId} AND team = {team}";
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

            _reader.Close();
            _conDatabase.Close();
            return playerData;
        }

        public void InsertTournament(Tournament<T1, T2> currentTournament)
        {
            _conDatabase.Open();

            string query = $"INSERT INTO tournament VALUES " +
                $"(NULL, " +
                $"{_sportId}, " +
                $"'{currentTournament.Title}', " +
                $"{currentTournament.NumberOfTeams}, " +
                $"{currentTournament.NumberOfRows})";

            var cmdDatabase = new MySqlCommand(query, _conDatabase);
            _reader = cmdDatabase.ExecuteReader();

            _reader.Close();
            _conDatabase.Close();
        }

        public void InsertTournamentTeams(Tournament<T1, T2> currentTournament)
        {
            _conDatabase.Open();
            int currentTournamentId;

            string query = $"SELECT tournament_ID FROM tournament " +
                $"ORDER BY tournament_ID DESC LIMIT 1;";
            var cmdDatabase = new MySqlCommand(query, _conDatabase);
            currentTournamentId = int.Parse(cmdDatabase.ExecuteScalar().ToString());

            foreach (var currentTeam in currentTournament.Teams)
            {
                query = $"INSERT INTO tournament_team VALUES " +
                $"({currentTournamentId}, " +
                $"{currentTeam.Id})";

                cmdDatabase = new MySqlCommand(query, _conDatabase);
                _reader.Close();
                _reader = cmdDatabase.ExecuteReader();
            }

            _reader.Close();
            _conDatabase.Close();
        }

        public void InsertGame(Game<T1, T2> currentGame)
        {
            _conDatabase.Open();

            int currentTournamentId;

            string query = $"SELECT tournament_ID FROM tournament " +
                $"ORDER BY tournament_ID DESC LIMIT 1;";
            var cmdDatabase = new MySqlCommand(query, _conDatabase);
            currentTournamentId = int.Parse(cmdDatabase.ExecuteScalar().ToString());

            query = $"INSERT INTO game VALUES " +
                $"(NULL, " +
                $"{currentTournamentId}, " +
                $"'{currentGame.Date}', " +
                $"{currentGame.HomeTeam.Id}, " +
                $"{currentGame.GuestTeam.Id}, " +
                $"{currentGame.HomeTeamScore}, " +
                $"{currentGame.GuestTeamScore}, " +
                $"{currentGame.Played});";

            cmdDatabase = new MySqlCommand(query, _conDatabase);
            _reader = cmdDatabase.ExecuteReader();

            _reader.Close();
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
            
            _reader.Close();
            _conDatabase.Close();
        }

        public void UpdateData()
        {
            _conDatabase.Open();

            UpdateTeamData(
                ((ComboItem<Game<T1, T2>>)_userInterface.GameInput.SelectedItem).Object.HomeTeam);
            UpdateTeamData(
                ((ComboItem<Game<T1, T2>>)_userInterface.GameInput.SelectedItem).Object.GuestTeam);

            foreach (var player in (
                (ComboItem<Game<T1, T2>>)_userInterface.GameInput.SelectedItem).Object.HomeTeam.Players)
            {
                UpdatePlayerData(player);
            }

            foreach (var player in
                ((ComboItem<T1>)_userInterface.GameInput.SelectedItem).Object.Players)
            {
                UpdatePlayerData(player);
            }

            _reader.Close();
            _conDatabase.Close();
        }

        private void UpdateTeamData(T1 team)
        {
            string query = $"UPDATE team SET " +
                $"points = {team.Points} " +
                $"WHERE team_ID = {team.Id};";
            var cmdDatabase = new MySqlCommand(query, _conDatabase);
            _reader = cmdDatabase.ExecuteReader();

            _reader.Close();
        }

        private void UpdatePlayerData(Player player)
        {
            string query = "";

            if (typeof(T2) == typeof(FootballPlayer))
            {
                query = $"UPDATE player SET " +
                $"goals = {((FootballPlayer)player).Goals}, " +
                $"assists = {((FootballPlayer)player).Assists}, " +
                $"yellow_cards = {((FootballPlayer)player).YellowCards}, " +
                $"red_cards = {((FootballPlayer)player).RedCards} " +
                $"WHERE player_ID = {((FootballPlayer)player).Id};";
            }
            else if (typeof(T2) == typeof(BasketballPlayer))
            {
                query = $"UPDATE player SET " +
                $"points = {((BasketballPlayer)player).Points}, " +
                $"removals = {((BasketballPlayer)player).Removals} " +
                $"WHERE player_ID = {((BasketballPlayer)player).Id};";
            }

            var cmdDatabase = new MySqlCommand(query, _conDatabase);
            _reader = cmdDatabase.ExecuteReader();

            _reader.Close();
        }
    }
}
