using System.Collections.Generic;

namespace OOP_TSU_Protocol
{
    public abstract class Team
    {
        public int Id { get; private set; }
        public static int SportId { get; protected set; }
        public string Name { get; private set; }
        protected string _location;
        protected int _points;
        public virtual ICollection<Player> TeamPlayers { get; set; }

        public void InitializeTeam<T1, T2>(List<string> data,
            UserInterface<T1, T2> newUserInterface, Database<T1, T2> newDatabase)
            where T1 : Team, new()
            where T2 : Player, new()
        {
            Id = int.Parse(data[0]);
            Name = data[2];
            _location = data[3];
            _points = int.Parse(data[4]);

            AddPlayers<T1, T2>(newUserInterface, newDatabase);
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
                currentPlayer.InitializePlayer(currentPlayerData);
                TeamPlayers.Add(currentPlayer);
                userInterface.AddPlayerComboItem(currentPlayer);
            }

            userInterface.AddTeamComboItemsToComboBox();
        }
    }
}
