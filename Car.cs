using System.Collections.Generic;
using System.Linq;

namespace CarService
{
    internal class Car
    {
        private readonly List<SparePart> _spareParts;
        private readonly ICar _carFactory;

        internal Car()
        {
            _carFactory = new Creator();
            _spareParts = _carFactory.Create();
        }

        internal List<SparePart> GetBrokenPart()
        {
            List<SparePart> BrokenSparePart = _spareParts.Where(part => part.IsBroken == false).ToList();

            return BrokenSparePart;
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
