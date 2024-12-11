using System.Collections.Generic;
using System.Linq;

namespace CarService
{
    internal class CarProvider :ICar
    {
        private static readonly PartProvider s_provider = new PartProvider();

        public List<SparePart> CreateListSpareParts()
        {
            List<SparePart> spareParts = new List<SparePart>();

            int maxPartCount = s_provider.Count;
            int minPartCount = 5;
            int partCount = UserUtil.GetRandom(maxPartCount, minPartCount);

            for (int i = 0; i < s_provider.Count; i++)
            {
                spareParts.Add(new SparePart(s_provider.GetSparePart(i).Name, s_provider.GetSparePart(i).IsBroken));
            }

            while (partCount != spareParts.Count)
            {
                spareParts.RemoveAt(UserUtil.GetRandom(spareParts.Count));
            }

            BreakParts(spareParts);

            return spareParts;
        }

        private void BreakParts(List<SparePart> spareParts)
        {
            int minBrokenParts = 1;
            int maxBrokenParts = spareParts.Count;
            int brokenPartsCount = UserUtil.GetRandom(maxBrokenParts, minBrokenParts);

            while (brokenPartsCount > 0)
            {
                List<SparePart> intactParts = spareParts.Where(part => part.IsBroken == false).ToList();

                intactParts[UserUtil.GetRandom(intactParts.Count)].Break();

                brokenPartsCount--;
            }
        }
    }
}
