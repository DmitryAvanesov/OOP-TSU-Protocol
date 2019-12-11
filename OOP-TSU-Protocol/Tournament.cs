using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_TSU_Protocol
{
    public class Tournament <T1, T2>
        where T1 : Team
        where T2 : Player
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public int NumberOfTeams;
        public int NumberOfRows;
        public ICollection<T1> Teams { get; private set; }

        public Tournament(int newId = 0, string newTitle = "", int newNumberOfTeams = 0,
            int newNumberOfRows = 0)
        {
            Id = newId;
            Title = newTitle;
            NumberOfTeams = newNumberOfTeams;
            NumberOfRows = newNumberOfRows;
            Teams = new List<T1>();
        }
    }
}
