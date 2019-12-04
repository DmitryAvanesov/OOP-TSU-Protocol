using System.Collections.Generic;
using System.Linq;

namespace OOP_TSU_Protocol
{
    class FootballTeam : Team
    {
        public FootballTeam(string[] data) : base(data)
        {
            TeamPlayers = new List<FootballPlayer>().Cast<Player>().ToList();
        }
    }
}
