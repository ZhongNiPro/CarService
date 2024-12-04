using System.Collections.Generic;
using System.Linq;

namespace CarService
{
    internal class Car
    {
        private List<SparePart> _car;
        private static PartProvider _provider = new PartProvider();

        public Car()
        {
            _car = new List<SparePart>();
            Create();
        }

        public List<SparePart> GetBrokenPart()
        {
            List<SparePart> BrokenSparePart = _car.Where(part => part.IsIntact == false).ToList();

            return BrokenSparePart;
        }

        public List<SparePart> GetSpareParts()
        {
            return _car.ToList();
        }

        public void Repair(SparePart newPart)                                   
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

            for (int i = 0; i < _provider.GetCount(); i++)
            {
                bool isIntact = chanceBreak >= UserUtil.GetRandom(chanceIntact + 1) ? false : true;
                _car.Add(new SparePart(_provider.GetCharacteristic(i).Name, isIntact));
            }
        }
    }
}
