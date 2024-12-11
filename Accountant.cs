using System.Collections.Generic;
using System.Linq;

namespace CarService
{
    internal class Accountant
    {
        private readonly int _penalty;
        private readonly int _fullPenalty;
        private readonly IMoney _money;
        private readonly CarServiceScreen _form;

        public Accountant(CarServiceScreen form)
        {
            _penalty = 200;
            _fullPenalty = 1000;
            _form = form;
            _money = new MoneyBallance();
        }

        public async void ReceiveIncome(int carNumber, SparePart part)
        {
            IPrice price = new PriceProvider();
            List<SparePart> priceSpareParts = price.FillPrice();

            SparePart brokenSparePart = priceSpareParts.Where(sparePart => sparePart.Name == part.Name).Single();

            _money.Increase(brokenSparePart.CostOfPurchasing);
            _money.Increase(brokenSparePart.CostOfRepair);

            await _form.ShowMessage($"Was repaired {part.Name} of {carNumber} Car" +
                 $"\ncar service receives  {brokenSparePart.CostOfPurchasing} + {brokenSparePart.CostOfRepair} ");

            await _form.ShowWallet(_money.ReceiveAmount().ToString());
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

            _money.Decrease(penalty);

            await _form.ShowWallet(_money.ReceiveAmount().ToString());
        }
    }
}
