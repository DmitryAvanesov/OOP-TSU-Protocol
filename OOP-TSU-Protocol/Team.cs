using System.Collections.Generic;

namespace OOP_TSU_Protocol
{
    public abstract class Team
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        protected string _location;
        public virtual ICollection<Player> TeamPlayers { get; set; }

        public Team(string[] data)
        {
            Id = int.Parse(data[0]);
            Name = data[1];
            _location = data[2];

            AddPlayers();
        }

        public void AddPlayers()
        {
          
        }
    }
}
