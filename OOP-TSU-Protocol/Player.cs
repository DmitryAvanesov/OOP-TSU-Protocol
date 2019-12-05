﻿using System.Collections.Generic;

namespace OOP_TSU_Protocol
{
    public abstract class Player
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Number { get; private set; }
        public string Position { get; private set; }
        public string Nationality { get; private set; }
        public string Team { get; private set; }

        public virtual void InitializePlayer(List<string> data)
        {
            Id = int.Parse(data[0]);
            Name = data[2];
            Number = int.Parse(data[3]);
            Position = data[4];
            Nationality = data[5];
            Team = data[6];  
        }
    }
}
