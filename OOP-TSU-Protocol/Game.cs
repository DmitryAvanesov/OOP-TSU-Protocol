using System;
using System.Collections.Generic;

namespace OOP_TSU_Protocol
{
    public class Game<T1, T2>
        where T1 : Team, new()
        where T2 : Player, new()
    {
        public DateTime Date { get; private set; }
        public T1 HomeTeam { get; private set; }
        public T1 GuestTeam { get; private set; }
        public int HomeTeamScore { get; private set; }
        public int GuestTeamScore { get; private set; }
        public ICollection<Event<T1, T2>> Events { get; set; }

        public Game(DateTime newDate, T1 newHostTeam, T1 newGuestTeam)
        {
            Date = newDate;
            HomeTeam = newHostTeam;
            GuestTeam = newGuestTeam;
            HomeTeamScore = 0;
            GuestTeamScore = 0;
            Events = new List<Event<T1, T2>>();
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
    }
}
