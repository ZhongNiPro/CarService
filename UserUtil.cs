using System;

namespace CarService
{
    internal static class UserUtil
    {
        private static readonly Random s_random = new Random();

        internal static int GetRandom(int max, int min = 0)
        {
            return s_random.Next(min, max);
        }
    }
}
