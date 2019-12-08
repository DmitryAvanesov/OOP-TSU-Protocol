using System.Collections.Generic;
using System.Linq;

namespace OOP_TSU_Protocol
{
    class BasketballTeam : Team
    {
        public BasketballTeam()
        {
            SportId = 2;
            Players = new List<BasketballPlayer>().Cast<Player>().ToList();
        }
    }
}
