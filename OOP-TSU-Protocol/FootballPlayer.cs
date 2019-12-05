using System.Collections.Generic;

namespace OOP_TSU_Protocol
{
    public class FootballPlayer : Player
    {
        public int Goals { get; private set; }
        public int Assists { get; private set; }
        public int YellowCards { get; private set; }
        public int RedCards { get; private set; }

        public override void InitializePlayer(List<string> data)
        {
            base.InitializePlayer(data);

            Goals = int.Parse(data[6]);
            Assists = int.Parse(data[7]);
            YellowCards = int.Parse(data[8]);
            RedCards = int.Parse(data[9]);
        }
    }
}
