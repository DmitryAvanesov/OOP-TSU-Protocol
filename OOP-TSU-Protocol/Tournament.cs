using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_TSU_Protocol
{
    public class Tournament <T1, T2>
        where T1 : Team, new()
        where T2 : Player, new()
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public int NumberOfTeams;
        public int NumberOfRows;
        public ICollection<T1> Teams { get; private set; }
        public IList<Game<T1, T2>> Games { get; private set; }

        public Tournament()
        {
            Teams = new List<T1>();
            Games = new List<Game<T1, T2>>();
        }

        public Tournament(List<string> newData)
        {
            Id = int.Parse(newData[0]);
            Title = newData[2];
            NumberOfTeams = int.Parse(newData[3]);
            NumberOfRows = int.Parse(newData[4]);
            Teams = new List<T1>();
            Games = new List<Game<T1, T2>>();
        }
    }
}
