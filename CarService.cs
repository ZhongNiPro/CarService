//using System.Collections.Generic;
//using System.Linq;
//using System.Windows.Forms;

//namespace CarService
//{
//    internal class CarService
//    {
//        private Storage _storage;
//        private Queue<Car> _cars;
//        private int _carQueueCount;
//        private Wallet _wallet;
//        private Form1 _form;
//        private bool _buttonClicked;

//        public CarService(Form1 form)
//        {
//            _storage = new Storage();
//            _cars = new Queue<Car>();
//            _carQueueCount = 10;
//            _wallet = new Wallet(form);
//            _form = form;
//            CarNumber = 1;

//            _form.UpdateButtonClicked += OnUpdateButtonClicked;

//            CreateQueue();
//        }

//        public int CarNumber { get; set; }

//        public void Work()
//        {
//            while (_cars.Count != 0)
//            {
//                Car car = _cars.Peek();
//                bool havePartInStorage = false;

//                List<SparePart> brokenParts = car.GetBrokenPart().ToList();

//                _form.ReceiveCarNumber(CarNumber);

//                foreach (SparePart part in brokenParts)
//                {
//                    if (_storage.TryGetParts(part))
//                    {
//                        havePartInStorage = true;
//                        break;
//                    }
//                }

//                if (havePartInStorage == false)
//                {
//                    _form.ShowCar(car.GetSpareParts());
//                    Application.DoEvents();
//                    _wallet.ReceiveFine(CarNumber, havePart: havePartInStorage);               
//                    WaitForButtonClick();                                                      
//                }

//                foreach (SparePart part in brokenParts.ToList())
//                {
//                    _form.ShowCar(car.GetSpareParts());
//                    Application.DoEvents();
//                    TryRepair(car, part);
//                    WaitForButtonClick();
//                }

//                CarNumber++;
//                _cars.Dequeue();
//            }
//        }

//        private void WaitForButtonClick()                              //??
//        {
//            _buttonClicked = false;

//            while (_buttonClicked == false)
//            {
//                Application.DoEvents();
//            }
//        }

//        private void OnUpdateButtonClicked()
//        {
//            _buttonClicked = true;
//        }

//        private void CreateQueue()
//        {
//            for (int i = 0; i < _carQueueCount; i++)
//            {
//                Car car = new Car();

//                if (car.GetBrokenPart().Count == 0)
//                {
//                    i--;
//                }
//                else
//                {
//                    _cars.Enqueue(car);
//                }
//            }
//        }

//        private void TryRepair(Car car, SparePart part)
//        {
//            if (_storage.TryGetParts(part))
//            {
//                SparePart newPart = _storage.UseUp(part);
//                car.Repair(newPart);
//                _wallet.ReceiveIncome(CarNumber, part);
//            }
//            else
//            {
//                _wallet.ReceiveFine(CarNumber, part);
//            }
//        }
//    }
//}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService
{
    internal class CarService
    {
        private Storage _storage;
        private Queue<Car> _cars;
        private int _carQueueCount;
        private Wallet _wallet;
        private Form1 _form;
        private TaskCompletionSource<bool> _buttonClickTcs;

        public CarService(Form1 form)
        {
            _storage = new Storage();
            _cars = new Queue<Car>();
            _carQueueCount = 10;
            _wallet = new Wallet(form);
            _form = form;
            CarNumber = 1;

            _form.UpdateButtonClicked += OnUpdateButtonClicked;

            CreateQueue();
        }

        public int CarNumber { get; set; }

        public async Task WorkAsync()
        {
            while (_cars.Count != 0)
            {
                Car car = _cars.Peek();
                bool havePartInStorage = false;

                List<SparePart> brokenParts = car.GetBrokenPart().ToList();

                await _form.ReceiveCarNumber(CarNumber);

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
                    _wallet.ReceiveFine(CarNumber, havePart: havePartInStorage);
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

                CarNumber++;
                _cars.Dequeue();
            }

            MessageBox.Show("All cars have been serviced. The program will exit.");
            await Task.Delay(100);
            Application.Exit();
        }

        private Task WaitForButtonClickAsync()
        {
            _buttonClickTcs = new TaskCompletionSource<bool>();
            return _buttonClickTcs.Task;
        }

        private void OnUpdateButtonClicked()
        {
            _buttonClickTcs?.SetResult(true);
        }

        private void CreateQueue()
        {
            for (int i = 0; i < _carQueueCount; i++)
            {
                Car car = new Car();

                if (car.GetBrokenPart().Count == 0)
                {
                    i--;
                }
                else
                {
                    _cars.Enqueue(car);
                }
            }
        }

        private void TryRepair(Car car, SparePart part)
        {
            if (_storage.TryGetParts(part))
            {
                SparePart newPart = _storage.UseUp(part);
                car.Repair(newPart);
                _wallet.ReceiveIncome(CarNumber, part);
            }
            else
            {
                _wallet.ReceiveFine(CarNumber, part);
            }
        }
    }
}
