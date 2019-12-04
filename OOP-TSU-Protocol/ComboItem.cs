namespace OOP_TSU_Protocol
{
    class ComboItem<T>
    {
        public string Name { get; private set; }
        public T Object { get; private set; }

        public override string ToString()
        {
            return Name;
        }

        public ComboItem(string newName, T newObject)
        {
            Name = newName;
            Object = newObject;
        }
    }
}
