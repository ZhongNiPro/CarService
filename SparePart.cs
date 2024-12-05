namespace CarService
{
    internal class SparePart
    {
        internal SparePart(string name, bool isBroken)
        {
            Name = name;
            IsBroken = isBroken;
        }

        internal SparePart(string name, bool isBroken, int costOfSparePart, int costOfRepair) : this(name, isBroken)
        {
            CostOfSparePart = costOfSparePart;
            CostOfRepair = costOfRepair;
        }

        internal string Name { get; private set; }
        internal bool IsBroken { get; private set; }
        internal int CostOfSparePart { get; private set; }
        internal int CostOfRepair { get; private set; }
    }
}
