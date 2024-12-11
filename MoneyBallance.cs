namespace CarService
{
    internal class MoneyBallance : IMoney
    {
        public MoneyBallance()
        {
            Amount = 0;
        }

        public int Amount { get; private set; }

        public int ReceiveAmount()
        {
            return Amount;
        }

        public void Increase(int value)
        {
            Amount += value;
        }

        public void Decrease(int value)
        {
            Amount -= value;
        }
    }
}
