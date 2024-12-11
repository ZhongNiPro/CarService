using System.Collections.Generic;
using System.Linq;

namespace CarService
{
    internal class Car
    {
        private static readonly ICar _carProvider = new CarProvider();
        private readonly List<SparePart> _spareParts;

        internal Car()
        {
            _spareParts = _carProvider.CreateListSpareParts();
        }

        internal List<SparePart> GetBrokenPart()
        {
            List<SparePart> brokenSparePart = _spareParts.Where(part => part.IsBroken == true).ToList();

            return brokenSparePart;
        }

        internal List<SparePart> GetSpareParts()
        {
            return _spareParts;
        }
    }
}
