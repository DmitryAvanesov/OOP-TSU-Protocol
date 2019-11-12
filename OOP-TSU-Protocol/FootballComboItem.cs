using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_TSU_Protocol
{
    class FootballComboItem
    {
        public string Name { get; private set; }
        public FootballPlayer Player { get; private set; }

        public override string ToString()
        {
            return Name;
        }

        public FootballComboItem(string thisName, FootballPlayer thisPlayer)
        {
            Name = thisName;
            Player = thisPlayer;
        }
    }
}
