namespace OOP_TSU_Protocol
{
    public abstract class Player
    {
        public int Id { get; private set; }
        public string Team { get; private set; }
        public string Number { get; private set; }
        public string Name { get; private set; }

        public Player(string[] data)
        {
            Id = int.Parse(data[0]);
            Team = data[1];
            Number = data[2];
            Name = data[3];
        }
    }
}
