using System.Collections.Generic;
using System.Linq;

namespace CarService
{
    internal class Storage
    {
        private List<SparePart> _carParts;

        internal Storage()
        {
            _carParts = new List<SparePart>();
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

        internal void AddSpareParts()
        {
            IStorageSupplier storageSupplier = new StoragePartsSupplier();
            List<SparePart> newSpareParts = storageSupplier.Supply().OfType<SparePart>().ToList();
            
            foreach (SparePart part in newSpareParts)
            {
                _carParts.Add(part);
            }
        }
    }
}
