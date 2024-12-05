using System.Collections.Generic;
using System.Linq;

namespace CarService
{
    internal class Storage
    {
        private static readonly PartProvider s_provider = new PartProvider();
        private readonly List<SparePart> _carParts;
        private readonly int _partMaxCount;

        internal Storage()
        {
            _carParts = new List<SparePart>();
            _partMaxCount = 5;

            Fill();
        }

        internal bool TryGetParts(SparePart part)
        {
            return _carParts.Any(sparePart => sparePart.Name == part.Name);
        }

        internal SparePart UseUp(SparePart part)
        {
            SparePart newPart = _carParts.First(sparePart => sparePart.Name == part.Name);
            _carParts.Remove(newPart);  

            return newPart;
        }

        private void Fill()
        {
            for (int i = 0; i < s_provider.GetCount; i++)
            {
                for (int j = 0; j < UserUtil.GetRandom(_partMaxCount + 1); j++)
                {
                    _carParts.Add(new SparePart(s_provider.GetCharacteristic(i).Name, s_provider.GetCharacteristic(i).IsIntact));
                }
            }
        }
    }
}
