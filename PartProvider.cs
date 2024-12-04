using System.Collections.Generic;

namespace CarService
{
    internal class PartProvider
    {
        private List<PartCharacteristic> _parts;

        public PartProvider()
        {
            _parts = new List<PartCharacteristic>()
            {
            new PartCharacteristic("spare part 1", true, 100, 100) ,
            new PartCharacteristic("spare part 2", true, 200, 200) ,
            new PartCharacteristic("spare part 3", true, 300, 300) ,
            new PartCharacteristic("spare part 4", true, 400, 400) ,
            new PartCharacteristic("spare part 5", true, 500, 500) ,
            new PartCharacteristic("spare part 6", true, 600, 600) ,
            new PartCharacteristic("spare part 7", true, 700, 700)
            };
        }

        public int GetCount()
        {
            return _parts.Count;
        }

        public PartCharacteristic GetCharacteristic(int index)
        {
            return _parts[index];
        }
    }
}
