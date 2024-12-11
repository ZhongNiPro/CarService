using System.Collections.Generic;

namespace CarService
{
    internal class QueueCreator
    {
        internal Queue<Car> CreateQueue(int carQueueCount)
        {
            Queue<Car> cars = new Queue<Car>();

            while (carQueueCount>0)
            {
                Car car = new Car();

                if (car.GetBrokenPart().Count != 0)
                {
                    cars.Enqueue(car);
                    carQueueCount--;
                }
            }

            return cars;
        }
    }
}
