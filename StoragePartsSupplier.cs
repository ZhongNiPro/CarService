using System.Collections.Generic;
using System.Linq;

namespace CarService
{
    internal class StoragePartsSupplier : IStorageSupplier
    {
        private static readonly PartProvider s_provider = new PartProvider();

        public List<SparePart> Supply()
        {
            List<SparePart> carParts = new List<SparePart>();
            int partMaxCount = 5;

            for (int i = 0; i < s_provider.Count; i++)
            {
                for (int j = 0; j < UserUtil.GetRandom(partMaxCount + 1); j++)
                {
                    carParts.Add(new SparePart(s_provider.GetSparePart(i).Name, s_provider.GetSparePart(i).IsBroken));
                }
            }

            return carParts.ToList();
        }
    }
}
