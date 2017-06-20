//--------------------------------------------------------------------------------
// <copyright file="RentalByWeek.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------

namespace BikeRental.Domain
{
    using System;

    /// <summary>
    /// Rental by week
    /// </summary>
    public class RentalByWeek : Rental
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalByWeek" /> class.
        /// </summary>
        public RentalByWeek()
        {
            this.RentalType = RentalType.ByWeek;
        }

        /// <summary>
        /// Rental price
        /// </summary>
        public override decimal Price
        {
            get
            {
                var span = DateTo - DateFrom;

                double weeks = Math.Truncate(span.TotalDays) / 7;

                var days = weeks - Math.Truncate(weeks);
                if (days > 0)
                {
                    weeks++;
                }

                return (decimal)Math.Truncate(weeks) * Prices.ByWeek;
            }
        }
    }
}
