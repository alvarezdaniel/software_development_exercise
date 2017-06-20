//--------------------------------------------------------------------------------
// <copyright file="Promo.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------

namespace BikeRental.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Promo class
    /// </summary>
    public class Promo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Promo" /> class.
        /// </summary>
        public Promo()
        {
            this.Rentals = new List<Rental>();
        }

        /// <summary>
        /// Gets or sets the promo identification
        /// </summary>
        public Guid PromoId { get; set; }

        /// <summary>
        /// Gets the promo rentals list
        /// </summary>
        public List<Rental> Rentals { get; private set; }

        /// <summary>
        /// Adds a new rental to a promo
        /// </summary>
        /// <param name="rentalType">rental type</param>
        /// <param name="dateFrom">starting date</param>
        /// <param name="prices">rental prices object</param>
        public void AddRental(RentalType rentalType, DateTime dateFrom, Prices prices)
        {
            var rental = Rental.ByType(rentalType);
            rental.Prices = prices;
            rental.BikeId = Guid.NewGuid();
            rental.DateFrom = dateFrom;
            this.Rentals.Add(rental);
        }
    }
}
