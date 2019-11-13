using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_TSU_Protocol
{
    class FootballTeamComboItem
    {
        public string Name { get; private set; }
        public FootballTeam Team { get; private set; }

        public override string ToString()
        {
            return Name;
        }

        public FootballTeamComboItem(string thisName, FootballTeam thisTeam)
        {
            Name = thisName;
            Team = thisTeam;
        }

        public void Suck()
        {

        }
    }
}
