using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_TSU_Protocol
{
    public class Event<T1, T2>
        where T1 : Team, new()
        where T2 : Player, new()
    {
        public Game<T1, T2> Game { get; private set; }
        public int Minute { get; private set; }
        public ProtocolForm<T1, T2>.EventType Type { get; private set; }
        public T2 Player { get; private set; }
        public T2 Assistant { get; private set; }

        public Event(Game<T1, T2> newGame, int newMinute,
            ProtocolForm<T1, T2>.EventType newType, T2 newPlayer, T2 newAssistant)
        {
            Game = newGame;
            Minute = newMinute;
            Type = newType;
            Player = newPlayer;
            Assistant = newAssistant;
        }
    }
}
