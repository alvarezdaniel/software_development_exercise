﻿//--------------------------------------------------------------------------------
// <copyright file="NonExistingPromoException.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------

namespace BikeRental.Domain.Exceptions
{
    using System;

    /// <summary>
    /// Exception for non existing promo
    /// </summary>
    [Serializable]
    public class NonExistingPromoException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NonExistingPromoException" /> class.
        /// </summary>
        /// <param name="message">message for the exception</param>
        public NonExistingPromoException(string message) : base(message)
        {
        }
    }
}
