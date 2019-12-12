using System;
using System.Collections.Generic;

namespace OOP_TSU_Protocol
{
    public class Game<T1, T2>
        where T1 : Team, new()
        where T2 : Player, new()
    {
        public int Id { get; private set; }
        public DateTime Date { get; set; }
        public T1 HomeTeam { get; private set; }
        public T1 GuestTeam { get; private set; }
        public int HomeTeamScore { get; private set; }
        public int GuestTeamScore { get; private set; }
        public int Played { get; set; }
        public ICollection<Event<T1, T2>> Events { get; set; }
        public string Name { get; private set; }

        public Game(T1 newHostTeam, T1 newGuestTeam)
        {
            HomeTeam = newHostTeam;
            GuestTeam = newGuestTeam;
            HomeTeamScore = 0;
            GuestTeamScore = 0;
            Played = 0;
            Events = new List<Event<T1, T2>>();
            Name = $"{HomeTeam.Name}  -  {GuestTeam.Name}";
        }

        public Game(List<string> data, T1 newHostTeam, T1 newGuestTeam)
        {
            Id = int.Parse(data[0]);
            Date = Convert.ToDateTime(data[2]);
            HomeTeam = newHostTeam;
            GuestTeam = newGuestTeam;
            HomeTeamScore = int.Parse(data[5]);
            GuestTeamScore = int.Parse(data[6]);
            Played = int.Parse(data[7]);
            Events = new List<Event<T1, T2>>();
            Name = $"{HomeTeam.Name} - {GuestTeam.Name}";
        }

        public void AddEvent(Game<T1, T2> newGame, int newMinute,
            ProtocolForm<T1, T2>.EventType newType, T2 newPlayer, T2 newAssistant)
        {
            Events.Add(new Event<T1, T2>(newGame, newMinute, newType, newPlayer, newAssistant));
        }

        public void IncreaseScore(T1 team, int score = 1)
        {
            if (team.Id == HomeTeam.Id)
            {
                HomeTeamScore += score;
            }
            else
            {
                GuestTeamScore += score;
            }
        }

        public void DistributePoints()
        {
            if (HomeTeamScore > GuestTeamScore)
            {
                if (typeof(T1) == typeof(FootballTeam))
                {
                    HomeTeam.Points = 3;
                    GuestTeam.Points = 0;
                }
                else if (typeof(T1) == typeof(BasketballTeam))
                {
                    HomeTeam.Points = 2;
                    GuestTeam.Points = 1;
                }
            }
            else if (HomeTeamScore < GuestTeamScore)
            {
                if (typeof(T1) == typeof(FootballTeam))
                {
                    HomeTeam.Points = 0;
                    GuestTeam.Points = 3;
                }
                else if (typeof(T1) == typeof(BasketballTeam))
                {
                    HomeTeam.Points = 1;
                    GuestTeam.Points = 2;
                }
            }
            else
            {
                if (typeof(T1) == typeof(FootballTeam))
                {
                    HomeTeam.Points = 1;
                    GuestTeam.Points = 1;
                }
                else if (typeof(T1) == typeof(BasketballTeam))
                {
                    HomeTeam.Points = 1;
                    GuestTeam.Points = 1;
                }
            }
        }
    }
}
