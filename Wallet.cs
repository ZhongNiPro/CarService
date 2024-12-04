using System.Collections.Generic;
using System.Linq;

namespace CarService
{
    internal class Wallet
    {
        private int _amount;
        private int _penalty;
        private int _fullPenalty;
        private PartProvider _partProvider;
        private List<PartCharacteristic> _price;
        private Form1 _form;

        public Wallet(Form1 form)
        {
            _amount = 0;
            _penalty = 200;
            _fullPenalty = 1000;
            _partProvider = new PartProvider();
            _price = new List<PartCharacteristic>();
            _form = form;
            FillPrice();
        }

        public async void ReceiveIncome(int carNumber, SparePart part)
        {
            PartCharacteristic brokenSparePart = _price.Where(sparePart => sparePart.Name == part.Name).Single();
            _amount += brokenSparePart.CostOfSparePart;
            _amount += brokenSparePart.CostOfRepair;
            await _form.ShowMessage($"Was repaired {part.Name} of {carNumber} Car" +
                 $"\ncar service receives  {brokenSparePart.CostOfSparePart} + {brokenSparePart.CostOfRepair} ");
            await _form.ShowWallet(_amount.ToString());
        }

        public async void ReceiveFine(int carNumber, SparePart part = null, bool havePart = true)
        {
            int penalty;

            if (havePart)
            {
                penalty = _penalty;
                await _form.ShowMessage($"Can't fix {part.Name} of {carNumber} Car" +
                      $"\ncar service receives a fine of -{penalty} ");
            }
            else
            {
                penalty = _fullPenalty;
                await _form.ShowMessage($"\nThere are no suitable spare parts for this car {carNumber}" +
                       $"\nCar service receives a fine of -{penalty}  ");
            }

            _amount -= penalty;
            await _form.ShowWallet(_amount.ToString());
        }

        private void FillPrice()
        {
            for (int i = 0; i < _partProvider.GetCount(); i++)
            {
                _price.Add(_partProvider.GetCharacteristic(i));
            }
        }
    }
}
