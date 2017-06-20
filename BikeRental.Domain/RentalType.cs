//--------------------------------------------------------------------------------
// <copyright file="RentalType.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------
namespace BikeRental.Domain
{
    /// <summary>
    /// Rental types
    /// </summary>
    public enum RentalType
    {
        /// <summary>
        /// Rental type by hour
        /// </summary>
        ByHour,

        /// <summary>
        /// Rental type by day
        /// </summary>
        ByDay,

        /// <summary>
        /// Rental type by week
        /// </summary>
        ByWeek
    }
}
