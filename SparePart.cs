namespace CarService
{
    internal class SparePart
    {
        internal SparePart(string name, bool isIntact)
        {
            Name = name;
            IsIntact = isIntact;
        }

        internal string Name { get; private set; }
        internal bool IsIntact { get; private set; }
    }
}
