using System.Collections.Generic;

namespace OOP_TSU_Protocol
{
    public class FootballPlayer : Player
    {
        public int Goals { get; private set; }
        public int Assists { get; private set; }
        public int YellowCards { get; private set; }
        public int RedCards { get; private set; }

        public override void InitializePlayer(List<string> data, Team newTeam)
        {
            base.InitializePlayer(data, newTeam);

            Goals = int.Parse(data[7]);
            Assists = int.Parse(data[8]);
            YellowCards = int.Parse(data[9]);
            RedCards = int.Parse(data[10]);
        }

        public override void IncreaseScore(int score)
        {
            Goals += score;
        }

        public void AddAssist()
        {
            Assists++;
        }

        public void GetYellowCard()
        {
            YellowCards++;
        }

        public void GetRedCard()
        {
            RedCards++;
        }
    }
}
