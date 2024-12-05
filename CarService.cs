using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService
{
    internal class CarService
    {
        private readonly Storage _storage;
        private readonly Queue<Car> _cars;
        private readonly int _carQueueCount;
        private readonly Wallet _wallet;
        private readonly CarServiceScreen _form;
        private readonly IQueue _carFactory;
        private int _carNumber;
        private TaskCompletionSource<bool> _buttonClickTCS;

        internal CarService(CarServiceScreen form)
        {
            _storage = new Storage();
            _cars = new Queue<Car>();
            _carQueueCount = 10;
            _carFactory = new Creator();
            _wallet = new Wallet(form);
            _form = form;
            _carNumber = 1;

            _form.UpdateButtonClicked += OnUpdateButtonClicked;

            _cars = _carFactory.CreateQueue(_carQueueCount);
        }

        internal async Task WorkAsync()
        {
            while (_cars.Count != 0)
            {
                Car car = _cars.Peek();
                List<SparePart> brokenParts = car.GetBrokenPart().ToList();

                await _form.ReceiveCarNumber(_carNumber);

                bool havePartInStorage = false;

                foreach (SparePart part in brokenParts)
                {
                    if (_storage.TryGetParts(part))
                    {
                        havePartInStorage = true;
                        break;
                    }
                }

                if (havePartInStorage == false)
                {
                    await _form.ShowCar(car.GetSpareParts());
                    _wallet.ReceiveFine(_carNumber, havePart: havePartInStorage);
                    await WaitForButtonClickAsync();
                }
                else
                {
                    foreach (SparePart part in brokenParts.ToList())
                    {
                        await _form.ShowCar(car.GetSpareParts());
                        TryRepair(car, part);
                        await WaitForButtonClickAsync();
                    }
                }

                _carNumber++;
                _cars.Dequeue();
            }

            MessageBox.Show("All cars have been serviced. The program will exit.");
            await Task.Delay(100);
            Application.Exit();
        }

        private Task WaitForButtonClickAsync()
        {
            _buttonClickTCS = new TaskCompletionSource<bool>();
            return _buttonClickTCS.Task;
        }

        private void OnUpdateButtonClicked()
        {
            _buttonClickTCS?.SetResult(true);
        }

        private void TryRepair(Car car, SparePart part)
        {
            if (_storage.TryGetParts(part))
            {
                SparePart newPart = _storage.UseUp(part);
                car.Repair(newPart);
                _wallet.ReceiveIncome(_carNumber, part);
            }
            else
            {
                _wallet.ReceiveFine(_carNumber, part);
            }
        }
    }
}
