using System.Collections.Generic;

namespace CarService
{
    internal interface IStorageSupplier
    {
        internal List<SparePart> Supply();
    }
}
