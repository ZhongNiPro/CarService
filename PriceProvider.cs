using System.Collections.Generic;

namespace CarService
{
    internal class PriceProvider : IPrice
    {
        private static readonly PartProvider s_partProvider = new PartProvider();

        public List<SparePart> FillPrice()
        {
            List<SparePart> price = new List<SparePart>();

            for (int i = 0; i < s_partProvider.Count; i++)
            {
                price.Add(s_partProvider.GetSparePart(i));
            }

            return price;
        }
    }
}
