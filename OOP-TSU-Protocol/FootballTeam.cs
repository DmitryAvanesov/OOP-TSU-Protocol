using System.Collections.Generic;
using System.Linq;

namespace OOP_TSU_Protocol
{
    class FootballTeam : Team
    {
        public FootballTeam()
        {          
            Players = new List<FootballPlayer>().Cast<Player>().ToList();
        }
    }
}
