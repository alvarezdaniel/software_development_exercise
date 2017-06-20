//--------------------------------------------------------------------------------
// <copyright file="RentalByDay.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------

namespace BikeRental.Domain
{
    using System;

    /// <summary>
    /// Rental by day
    /// </summary>
    public class RentalByDay : Rental
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalByDay" /> class.
        /// </summary>
        public RentalByDay()
        {
            this.RentalType = RentalType.ByDay;
        }

        /// <summary>
        /// Rental price
        /// </summary>
        public override decimal Price
        {
            get
            {
                var span = DateTo - DateFrom;

                var days = Math.Truncate(span.TotalDays);
                if (span.Hours > 0)
                {
                    days++;
                }

                return (decimal)days * Prices.ByDay;
            }
        }
    }
}
