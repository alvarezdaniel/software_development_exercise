using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental.Domain.Exceptions
{
    [Serializable]
    public class InvalidRentalsCountException : Exception
    {
        public InvalidRentalsCountException(string message) : base(message)
        {
        }
    }
}
