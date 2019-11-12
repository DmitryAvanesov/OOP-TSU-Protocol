using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_TSU_Protocol
{
    class FootballPlayer
    {
        private int _number;
        public string _name;

        public FootballPlayer(int thisNumber, string thisName)
        {
            _number = thisNumber;
            _name = thisName;
        }
    }
}
