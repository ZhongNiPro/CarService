using System.Collections.Generic;
using System.Linq;

namespace CarService
{
    internal class Wallet
    {
        private static readonly PartProvider s_partProvider = new PartProvider();
        private readonly int _penalty;
        private readonly int _fullPenalty;
        private readonly List<SparePart> _price;
        private readonly CarServiceScreen _form;
        private int _amount;

        public Wallet(CarServiceScreen form)
        {
            _amount = 0;
            _penalty = 200;
            _fullPenalty = 1000;
            _price = new List<SparePart>();
            _form = form;

            FillPrice();
        }

        public async void ReceiveIncome(int carNumber, SparePart part)
        {
            SparePart brokenSparePart = _price.Where(sparePart => sparePart.Name == part.Name).Single();

            _amount += brokenSparePart.CostOfPurchasing;
            _amount += brokenSparePart.CostOfRepair;

            await _form.ShowMessage($"Was repaired {part.Name} of {carNumber} Car" +
                 $"\ncar service receives  {brokenSparePart.CostOfPurchasing} + {brokenSparePart.CostOfRepair} ");

            await _form.ShowWallet(_amount.ToString());
        }

        public async void ReceiveFine(int carNumber, SparePart part = null, bool havePart = true)
        {
            int penalty;

            if (havePart)
            {
                penalty = _penalty;

                await _form.ShowMessage($"Can't fix {part.Name} of {carNumber} Car" +
                      $"\ncar service receives a fine of -{penalty}");
            }
            else
            {
                penalty = _fullPenalty;

                await _form.ShowMessage($"There are no suitable spare parts for car {carNumber}" +
                       $"\nCar service receives a fine of -{penalty}");
            }

            _amount -= penalty;

            await _form.ShowWallet(_amount.ToString());
        }

        private void FillPrice()
        {
            for (int i = 0; i < s_partProvider.GetCount; i++)
            {
                _price.Add(s_partProvider.GetSparePart(i));
            }
        }
    }
}
