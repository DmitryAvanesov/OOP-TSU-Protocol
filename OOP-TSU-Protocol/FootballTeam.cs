using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_TSU_Protocol
{
    class FootballTeam
    {
        private List<FootballPlayer> _teamPlayers;
        private string _name;
        private string _location;

        public FootballTeam(string thisName, string thisLocation)
        {
            _name = thisName;
            _location = thisLocation;

            _teamPlayers = new List<FootballPlayer>();
        }

        public void AddPlayers(IList<FootballPlayer> thisTeamPlayers)
        {
            _teamPlayers.AddRange(thisTeamPlayers);
        }
    }
}
