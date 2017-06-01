using System;

namespace BikeRental.Domain.Exceptions
{
    [Serializable]
    public class NonExistingPromoException : Exception
    {
        public NonExistingPromoException(string message) : base(message)
        {
        }
    }
}
