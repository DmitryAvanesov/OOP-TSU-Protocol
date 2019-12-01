namespace OOP_TSU_Protocol
{
    class FootballTeamComboItem
    {
        public string Name { get; private set; }
        public FootballTeam Team { get; private set; }

        public override string ToString()
        {
            return Name;
        }

        public FootballTeamComboItem(string thisName, FootballTeam thisTeam)
        {
            Name = thisName;
            Team = thisTeam;
        }
    }
}
