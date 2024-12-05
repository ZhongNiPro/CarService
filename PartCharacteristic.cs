namespace CarService
{
    internal class PartCharacteristic
    {
        internal PartCharacteristic(string name, bool isIntact, int costOfSparePart, int costOfRepair)
        {
            Name = name;
            IsIntact = isIntact;
            CostOfSparePart = costOfSparePart;
            CostOfRepair = costOfRepair;
        }

        internal string Name { get; private set; }
        internal bool IsIntact { get; private set; }
        internal int CostOfSparePart { get; private set; }
        internal int CostOfRepair { get; private set; }
    }
}
