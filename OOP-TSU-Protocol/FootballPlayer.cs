using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_TSU_Protocol
{
    class FootballPlayer
    {
        private string _team;
        private string _number;
        public string Name { get; private set; }

        public FootballPlayer(string[] data)
        {
            _team = data[0];
            _number = data[1];
            Name = data[2];
        }
    }
}
