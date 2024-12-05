using System.Collections.Generic;

namespace CarService
{
    internal class PartProvider
    {
        private readonly List<SparePart> _parts;

        internal PartProvider()
        {
            _parts = new List<SparePart>()
            {
            new SparePart("spare part 1", false, 100, 100) ,
            new SparePart("spare part 2", false, 200, 200) ,
            new SparePart("spare part 3", false, 300, 300) ,
            new SparePart("spare part 4", false, 400, 400) ,
            new SparePart("spare part 5", false, 500, 500) ,
            new SparePart("spare part 6", false, 600, 600) ,
            new SparePart("spare part 7", false, 700, 700)
            };
        }

        internal int GetCount => _parts.Count;

        internal SparePart GetCharacteristic(int index)
        {
            return _parts[index];
        }
    }
}
