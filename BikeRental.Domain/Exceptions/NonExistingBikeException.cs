using System;

namespace BikeRental.Domain.Exceptions
{
    [Serializable]
    public class NonExistingBikeException : Exception
    {
        public NonExistingBikeException(string message) : base(message)
        {
        }
    }
}
