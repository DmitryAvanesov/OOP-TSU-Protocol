using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_TSU_Protocol
{
    class FootballTeam
    {
        const string PathToFootballPlayerTXT =
            @"C:\Users\DmitryAvanesov\source\repos\OOP-TSU-Protocol\OOP-TSU-Protocol\Data\FootballPlayer.txt";

        private List<FootballPlayer> _teamPlayers;
        public string Name { get; private set; }
        private string _location;

        public FootballTeam(string[] data)
        {
            Name = data[0];
            _location = data[1];

            _teamPlayers = new List<FootballPlayer>();
        }

        public void AddPlayers()
        {
            foreach (string line in File.ReadAllLines(PathToFootballPlayerTXT))
            {
                _teamPlayers.Add(new FootballPlayer(line.Split(';')));
            }
        }
    }
}
