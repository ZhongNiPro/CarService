namespace CarService
{
    internal class PartCharacteristic
    {
        public PartCharacteristic(string name, bool isIntact, int costOfSparePart, int costOfRepair)
        {
            Name = name;
            IsIntact = isIntact;
            CostOfSparePart = costOfSparePart;
            CostOfRepair = costOfRepair;
        }

        public string Name { get; private set; }
        public bool IsIntact { get; private set; }
        public int CostOfSparePart { get; private set; }
        public int CostOfRepair { get; private set; }
    }
}
