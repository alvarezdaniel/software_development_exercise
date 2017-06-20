//--------------------------------------------------------------------------------
// <copyright file="Prices.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------

namespace BikeRental.Domain
{
    /// <summary>
    /// Prices class
    /// </summary>
    public class Prices
    {
        /// <summary>
        /// Gets or sets the price by hour
        /// </summary>
        public decimal ByHour { get; set; }

        /// <summary>
        /// Gets or sets the price by day
        /// </summary>
        public decimal ByDay { get; set; }

        /// <summary>
        /// Gets or sets the price by week
        /// </summary>
        public decimal ByWeek { get; set; }
    }
}
