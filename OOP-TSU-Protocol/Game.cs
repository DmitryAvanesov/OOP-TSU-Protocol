using System;
using System.Collections.Generic;

namespace OOP_TSU_Protocol
{
    public class Game<T1, T2>
        where T1 : Team, new()
        where T2 : Player, new()
    {
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public T1 HomeTeam { get; private set; }
        public T1 GuestTeam { get; private set; }
        public int HomeTeamScore { get; private set; }
        public int GuestTeamScore { get; private set; }
        public ICollection<Event<T1, T2>> Events { get; set; }
        public string Name { get; private set; }

    public Game(int newId, DateTime newDate, T1 newHostTeam, T1 newGuestTeam,
            int newHomeTeamScore = 0, int newGuestTeamScore = 0)
        {
            Id = newId;
            Date = newDate;
            HomeTeam = newHostTeam;
            GuestTeam = newGuestTeam;
            HomeTeamScore = newHomeTeamScore;
            GuestTeamScore = newGuestTeamScore;
            Events = new List<Event<T1, T2>>();
            Name = $"{HomeTeam.Name}  {HomeTeamScore} : {GuestTeamScore}  {GuestTeam.Name}";
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
