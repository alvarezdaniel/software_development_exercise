//--------------------------------------------------------------------------------
// <copyright file="RentalByHour.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------

namespace BikeRental.Domain
{
    using System;

    /// <summary>
    /// Rental by hour
    /// </summary>
    public class RentalByHour : Rental
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalByHour" /> class.
        /// </summary>
        public RentalByHour()
        {
            this.RentalType = RentalType.ByHour;
        }

        /// <summary>
        /// Rental price
        /// </summary>
        public override decimal Price
        {
            get
            {
                var span = DateTo - DateFrom;

                var hours = Math.Truncate(span.TotalHours);
                if (span.Minutes > 0)
                {
                    hours++;
                }

                return (decimal)hours * Prices.ByHour;
            }
        }
    }
}
