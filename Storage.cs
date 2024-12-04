using System.Collections.Generic;
using System.Linq;

namespace CarService
{
    internal class Storage
    {
        private List<SparePart> _carParts;
        private PartProvider _provider;
        private int _partMaxCount;

        public Storage()
        {
            _carParts = new List<SparePart>();
            _provider = new PartProvider();
            _partMaxCount = 5;
            Fill();
        }

        public bool TryGetParts(SparePart part)
        {
            return _carParts.Any(sparePart => sparePart.Name == part.Name);
        }

        public SparePart UseUp(SparePart part)
        {
            SparePart newPart = _carParts.First(sparePart => sparePart.Name == part.Name);
            _carParts.Remove(newPart);  
            return newPart;
        }

        private void Fill()
        {
            for (int i = 0; i < _provider.GetCount(); i++)
            {
                for (int j = 0; j < UserUtil.GetRandom(_partMaxCount + 1); j++)
                {
                    _carParts.Add(new SparePart(_provider.GetCharacteristic(i).Name, _provider.GetCharacteristic(i).IsIntact));
                }
            }
        }
    }
}
