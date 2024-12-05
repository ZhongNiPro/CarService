using System.Collections.Generic;
using System.Linq;

namespace CarService
{
    internal class Car
    {
        private static readonly ICar _carFactory = new Creator();
        private readonly List<SparePart> _spareParts;

        internal Car()
        {
            _spareParts = _carFactory.CreateListSpareParts();
        }

        internal List<SparePart> GetBrokenPart()
        {
            List<SparePart> brokenSparePart = _spareParts.Where(part => part.IsBroken == false).ToList();

            return brokenSparePart;
        }

        internal List<SparePart> GetSpareParts()
        {
            return _spareParts.ToList();
        }

        internal void Repair(SparePart newPart)
        {
            for (int i = 0; i < _spareParts.Count; i++)
            {
                if (_spareParts[i].Name == newPart.Name)
                {
                    _spareParts[i] = newPart;
                    break;
                }
            }
        }
    }
}
