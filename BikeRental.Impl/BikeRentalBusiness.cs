//--------------------------------------------------------------------------------
// <copyright file="BikeRentalBusiness.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------

namespace BikeRental.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Domain;
    using Domain.Exceptions;
    using Interfaces;
    using log4net;

    /// <summary>
    /// Rental business
    /// </summary>
    public class BikeRentalBusiness : IBikeRentalBusiness
    {
        /// <summary>
        /// Object used to log
        /// </summary>
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// List of rentals
        /// </summary>
        private List<Rental> rentals;

        /// <summary>
        /// List of promos
        /// </summary>
        private List<Promo> promos;

        /// <summary>
        /// Prices per week, day and hour object
        /// </summary>
        private Prices prices;

        /// <summary>
        /// Initializes a new instance of the <see cref="BikeRentalBusiness" /> class.
        /// </summary>
        public BikeRentalBusiness()
        {
            this.rentals = new List<Rental>();
            this.promos = new List<Promo>();
            this.prices = new Prices
            {
                ByHour = 5,
                ByDay = 20,
                ByWeek = 60
            };
        }

        /// <summary>
        /// Checks out a bike
        /// </summary>
        /// <param name="rentalType">rental type</param>
        /// <param name="dateFrom">finish date</param>
        /// <returns>returns the price to charge</returns>
        public Guid CheckoutBike(RentalType rentalType, DateTime dateFrom)
        {
            var rental = Rental.ByType(rentalType);
            rental.Prices = this.prices;

            this.log.Debug($"Checkout bike: rental type = {rentalType}, from: {dateFrom}");

            rental.BikeId = Guid.NewGuid();
            rental.DateFrom = dateFrom;
            this.rentals.Add(rental);

            this.log.Debug($"Returning BikeId {rental.BikeId}");

            return rental.BikeId;
        }

        /// <summary>
        /// Checks in a bike
        /// </summary>
        /// <param name="bikeId">bike identification</param>
        /// <param name="dateTo">finish date</param>
        /// <returns>returns the price to charge</returns>
        public decimal CheckInBike(Guid bikeId, DateTime dateTo)
        {
            this.log.Debug($"Checkin bike: bike id = {bikeId}, to: {dateTo}");

            var rental = this.rentals.Find(x => x.BikeId == bikeId);
            if (rental == null)
            {
                var error = $"BikeId = {bikeId} does not exist";
                this.log.Error(error);
                throw new NonExistingBikeException(error);
            }

            this.rentals.Remove(rental);

            rental.DateTo = dateTo;
            var price = rental.Price;

            this.log.Debug($"Returning Price {price}");
            return price;
        }

        /// <summary>
        /// Checks out bikes in promo
        /// </summary>
        /// <param name="rentalTypes">list of rental types to check out</param>
        /// <param name="dateFrom">starting date</param>
        /// <returns>returns the promo identification</returns>
        public Guid CheckoutBikesPromo(List<RentalType> rentalTypes, DateTime dateFrom)
        {
            if ((rentalTypes == null) || (rentalTypes.Count < 3) || (rentalTypes.Count > 5))
            {
                var error = $"Invalid number of rentals in CheckoutBikes";
                this.log.Error(error);
                throw new InvalidRentalsCountException(error);
            }

            this.log.Debug($"Checkout bikes: {rentalTypes.Count} bikes, from: {dateFrom}");

            var promo = new Promo();
            promo.PromoId = Guid.NewGuid();
            foreach (var rentalType in rentalTypes)
            {
                promo.AddRental(rentalType, dateFrom, this.prices);
            }

            this.promos.Add(promo);

            this.log.Debug($"Returning PromoId {promo.PromoId}");

            return promo.PromoId;
        }

        /// <summary>
        /// Checks in bikes in promo
        /// </summary>
        /// <param name="promoId">promo identification</param>
        /// <param name="dateTo">finish date</param>
        /// <returns>returns price to charge</returns>
        public decimal CheckInBikesPromo(Guid promoId, DateTime dateTo)
        {
            this.log.Debug($"Checkin bikes in promo: promo id = {promoId}, to: {dateTo}");

            var promo = this.promos.Find(x => x.PromoId == promoId);
            if (promo == null)
            {
                var error = $"PromoId = {promoId} does not exist";
                this.log.Error(error);
                throw new NonExistingPromoException(error);
            }

            this.promos.Remove(promo);

            decimal price = 0;
            foreach (var rental in promo.Rentals)
            {
                rental.DateTo = dateTo;
                price += rental.Price;
            }

            price = price * (decimal)0.7;

            this.log.Debug($"Returning Price {price}");
            return price;
        }
    }
}
