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
            new SparePart("Spark plug", false, 100, 100) ,
            new SparePart("Brake pad", false, 200, 200) ,
            new SparePart("Bumper", false, 300, 300) ,
            new SparePart("Air bag", false, 400, 400) ,
            new SparePart("Engine", false, 500, 500) ,
            new SparePart("Gearbox", false, 600, 600) ,
            new SparePart("Suspension", false, 700, 700)
            };
        }

        internal int Count => _parts.Count;

        internal SparePart GetSparePart(int index)
        {
            return _parts[index];
        }
    }
}
