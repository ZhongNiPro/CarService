namespace CarService
{
    internal interface IMoney
    {
        internal int ReceiveAmount();

        internal void Increase(int value);

        internal void Decrease(int value);
    }
}
