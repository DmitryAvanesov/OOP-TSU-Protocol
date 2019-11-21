using System.Collections.Generic;
using System.IO;

namespace OOP_TSU_Protocol
{
    class FootballTeam
    {
        const string PathToFootballPlayerTXT = @"\..\..\Data\FootballPlayer.txt";

        public IList<FootballPlayer> TeamPlayers;
        public string Name { get; private set; }
        private int _id;
        private string _location;

        public FootballTeam(string[] data)
        {
            _id = int.Parse(data[0]);
            Name = data[1];
            _location = data[2];

            TeamPlayers = new List<FootballPlayer>();
            AddPlayers();
        }

        public void AddPlayers()
        {
            foreach (string line in File.ReadAllLines(Directory.GetCurrentDirectory() + PathToFootballPlayerTXT))
            {
                int currentTeamId = int.Parse(line.Split(';')[0]);

                if (currentTeamId == _id)
                {
                    TeamPlayers.Add(new FootballPlayer(line.Split(';')));
                }
            }
        }
    }
}
