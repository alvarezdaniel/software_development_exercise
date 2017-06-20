//--------------------------------------------------------------------------------
// <copyright file="NonExistingBikeException.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------

namespace BikeRental.Domain.Exceptions
{
    using System;

    /// <summary>
    /// Exception for non existing bike in promo
    /// </summary>
    [Serializable]
    public class NonExistingBikeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NonExistingBikeException" /> class.
        /// </summary>
        /// <param name="message">message for the exception</param>
        public NonExistingBikeException(string message) : base(message)
        {
        }
    }
}
