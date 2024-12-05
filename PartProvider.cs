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
            new SparePart("spark plug", false, 100, 100) ,
            new SparePart("brake pad", false, 200, 200) ,
            new SparePart("bumper", false, 300, 300) ,
            new SparePart("air bag", false, 400, 400) ,
            new SparePart("engine", false, 500, 500) ,
            new SparePart("gearbox", false, 600, 600) ,
            new SparePart("suspension", false, 700, 700)
            };
        }

        internal int GetCount => _parts.Count;

        internal SparePart GetSparePart(int index)
        {
            return _parts[index];
        }
    }
}
