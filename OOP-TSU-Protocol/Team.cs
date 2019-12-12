using System.Collections.Generic;

namespace OOP_TSU_Protocol
{
    public abstract class Team
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        protected string _location;
        public int Points { get; private set; }
        public virtual ICollection<Player> Players { get; set; }

        public void InitializeTeam<T1, T2>(List<string> data,
            UserInterface<T1, T2> newUserInterface, Database<T1, T2> newDatabase)
            where T1 : Team, new()
            where T2 : Player, new()
        {
            Id = int.Parse(data[0]);
            Name = data[2];
            _location = data[3];
            Points = int.Parse(data[4]);

            AddPlayers(newUserInterface, newDatabase);
        }

        public void AddPlayers<T1, T2>(UserInterface<T1, T2> userInterface,
            Database<T1, T2> database)
            where T1 : Team, new()
            where T2 : Player, new()
        {
            T2 currentPlayer;
            var data = database.SelectPlayers(Id);

            foreach (var currentPlayerData in data)
            {
                currentPlayer = new T2();
                currentPlayer.InitializePlayer(currentPlayerData, this);
                Players.Add(currentPlayer);
            }
        }

        public void AddPoints(int points)
        {
            Points += points;
        }
    }
}
