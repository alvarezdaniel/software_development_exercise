//--------------------------------------------------------------------------------
// <copyright file="IBikeRentalBusiness.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------

namespace BikeRental.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Domain;

    /// <summary>
    /// Rental business interface
    /// </summary>
    public interface IBikeRentalBusiness
    {
        /// <summary>
        /// Checks out a bike
        /// </summary>
        /// <param name="rentalType">rental type</param>
        /// <param name="dateFrom">finish date</param>
        /// <returns>returns the price to charge</returns>
        Guid CheckoutBike(RentalType rentalType, DateTime dateFrom);

        /// <summary>
        /// Checks in a bike
        /// </summary>
        /// <param name="bikeId">bike identification</param>
        /// <param name="dateTo">finish date</param>
        /// <returns>returns the price to charge</returns>
        decimal CheckInBike(Guid bikeId, DateTime dateTo);

        /// <summary>
        /// Checks out bikes in promo
        /// </summary>
        /// <param name="rentalTypes">list of rental types to check out</param>
        /// <param name="dateFrom">starting date</param>
        /// <returns>returns the promo identification</returns>
        Guid CheckoutBikesPromo(List<RentalType> rentalTypes, DateTime dateFrom);

        /// <summary>
        /// Checks in bikes in promo
        /// </summary>
        /// <param name="promoId">promo identification</param>
        /// <param name="dateTo">finish date</param>
        /// <returns>returns price to charge</returns>
        decimal CheckInBikesPromo(Guid promoId, DateTime dateTo);
    }
}
