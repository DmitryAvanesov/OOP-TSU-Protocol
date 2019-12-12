using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_TSU_Protocol
{
    class BasketballPlayer : Player
    {
        public int Points { get; private set; }
        public int Removals { get; private set; }

        public override void InitializePlayer(List<string> data, Team newTeam)
        {
            base.InitializePlayer(data, newTeam);

            Points = int.Parse(data[11]);
            Removals = int.Parse(data[12]);
        }

        public override void IncreaseScore(int score)
        {
            Points += score;
        }

        public void GetRemoval()
        {
            Removals++;
        }
    }
}
