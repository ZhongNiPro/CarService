using System.Collections.Generic;

namespace CarService
{
    internal interface IQueue
    {
        internal Queue<Car> CreateQueue(int _carQueueCount);
    }
}
