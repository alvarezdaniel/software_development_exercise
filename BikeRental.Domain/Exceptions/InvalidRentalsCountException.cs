//--------------------------------------------------------------------------------
// <copyright file="InvalidRentalsCountException.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------

namespace BikeRental.Domain.Exceptions
{
    using System;

    /// <summary>
    /// Exception for promo with invalid rentals count
    /// </summary>
    [Serializable]
    public class InvalidRentalsCountException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRentalsCountException" /> class.
        /// </summary>
        /// <param name="message">message for the exception</param>
        public InvalidRentalsCountException(string message) : base(message)
        {
        }
    }
}
