using System.Collections.Generic;
using System.Linq;

namespace CarService
{
    internal class Car
    {
        private static readonly PartProvider s_provider = new PartProvider();
        private readonly List<SparePart> _car;

        internal Car()
        {
            _car = new List<SparePart>();

            Create();
        }

        internal List<SparePart> GetBrokenPart()
        {
            List<SparePart> BrokenSparePart = _car.Where(part => part.IsIntact == false).ToList();

            return BrokenSparePart;
        }

        internal List<SparePart> GetSpareParts()
        {
            return _car.ToList();
        }

        internal void Repair(SparePart newPart)                                   
        {
            for (int i =  0; i < _car.Count; i++) 
            {
                if (_car[i].Name == newPart.Name)
                {
                    _car[i] = newPart;
                    break;
                }
            }
        }

        private void Create()
        {
            int chanceIntact = 100;
            int chanceBreak = 40;

            for (int i = 0; i < s_provider.GetCount; i++)
            {
                bool isIntact = chanceBreak >= UserUtil.GetRandom(chanceIntact + 1) ? false : true;
                _car.Add(new SparePart(s_provider.GetCharacteristic(i).Name, isIntact));
            }
        }
    }
}
