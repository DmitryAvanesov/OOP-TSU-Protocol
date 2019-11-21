namespace OOP_TSU_Protocol
{
    class EventTypeComboItem
    {
        public string Name { get; private set; }
        public enum FootballEventTypes { Goal, YellowCard, RedCard };

        public override string ToString()
        {
            return Name;
        }

        public EventTypeComboItem()
        {
            Name = thisName;
            Player = thisPlayer;
        }
    }
}
