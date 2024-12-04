namespace CarService
{
    internal class SparePart
    {
        public SparePart(string name, bool isIntact)
        {
            Name = name;
            IsIntact = isIntact;
        }

        public string Name { get; private set; }
        public bool IsIntact { get; private set; }
    }
}
