//--------------------------------------------------------------------------------
// <copyright file="Rental.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------

namespace BikeRental.Domain
{
    using System;

    /// <summary>
    /// Abstract rental
    /// </summary>
    public abstract class Rental
    {
        /// <summary>
        /// Gets or sets the rental identification
        /// </summary>
        public Guid BikeId { get; set; }

        /// <summary>
        /// Gets or sets the rental starting date
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Gets or sets the rental finish date
        /// </summary>
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Gets the rental price
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// Gets or sets the rental price
        /// </summary>
        public Prices Prices { get; set; }

        /// <summary>
        /// Gets or sets the rental type
        /// </summary>
        protected RentalType RentalType { get; set; }

        /// <summary>
        /// Creates a new rental by passing its type
        /// </summary>
        /// <param name="rentalType">rental type</param>
        /// <returns>returns a new rental</returns>
        public static Rental ByType(RentalType rentalType)
        {
            switch (rentalType)
            {
                case RentalType.ByHour:
                        return new RentalByHour(); 
                case RentalType.ByDay:
                    return new RentalByDay();
                case RentalType.ByWeek: 
                default:
                     return new RentalByWeek();
            }
        }
    }
}
