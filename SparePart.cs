namespace CarService
{
    internal class SparePart
    {
        internal SparePart(string name, bool isBroken)
        {
            Name = name;
            IsBroken = isBroken;
        }

        internal SparePart(string name, bool isBroken, int costOfPurchasing, int costOfRepair) : this(name, isBroken)
        {
            CostOfPurchasing = costOfPurchasing;
            CostOfRepair = costOfRepair;
        }

        internal string Name { get; private set; }
        internal bool IsBroken { get; private set; }
        internal int CostOfPurchasing { get; private set; }
        internal int CostOfRepair { get; private set; }
    }
}
