using System.Collections.Generic;

namespace CarService
{
    internal class Creator : ICar, IQueue
    {
        private static readonly PartProvider s_provider = new PartProvider();

        public List<SparePart> CreateListSpareParts()
        {
            List<SparePart> spareParts = new List<SparePart>();

            int chanceBreak = 100;
            int chanceIntact = 60;

            for (int i = 0; i < s_provider.GetCount; i++)
            {
                bool isBreak = chanceIntact >= UserUtil.GetRandom(chanceBreak + 1);
                spareParts.Add(new SparePart(s_provider.GetCharacteristic(i).Name, isBreak));
            }

            return spareParts;
        }

        public Queue<Car> CreateQueue(int carQueueCount)
        {
            Queue<Car> cars = new Queue<Car>();

            for (int i = 0; i < carQueueCount; i++)
            {
                Car car = new Car();

                if (car.GetBrokenPart().Count == 0)
                {
                    i--;
                }
                else
                {
                    cars.Enqueue(car);
                }
            }

            return cars;
        }
    }
}
