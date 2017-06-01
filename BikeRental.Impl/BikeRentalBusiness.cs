using BikeRental.Interfaces;
using BikeRental.Domain;
using System;
using System.Collections.Generic;
using log4net;
using System.Reflection;
using BikeRental.Domain.Exceptions;

namespace BikeRental.Impl
{
    public class BikeRentalBusiness : IBikeRentalBusiness
    {
        private List<Rental> _rentals;
        private List<Promo> _promos;
        private Prices _prices;
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public BikeRentalBusiness()
        {
            _rentals = new List<Rental>();
            _promos = new List<Promo>();
            _prices = new Prices
            {
                ByHour = 5,
                ByDay = 20,
                ByWeek = 60
            };
        }

        public Guid CheckoutBike(RentalType rentalType, DateTime dateFrom)
        {
            var rental = Rental.ByType(rentalType);
            rental.Prices = _prices;

            log.Debug($"Checkout bike: rental type = {rentalType}, from: {dateFrom}");

            rental.BikeId = Guid.NewGuid();
            rental.DateFrom = dateFrom;
            _rentals.Add(rental);

            log.Debug($"Returning BikeId {rental.BikeId}");

            return rental.BikeId;
        }

        public decimal CheckInBike(Guid bikeId, DateTime dateTo)
        {
            log.Debug($"Checkin bike: bike id = {bikeId}, to: {dateTo}");

            var rental = _rentals.Find(x => x.BikeId == bikeId);
            if (rental == null)
            {
                var error = $"BikeId = {bikeId} does not exist";
                log.Error(error);
                throw new NonExistingBikeException(error);
            }

            _rentals.Remove(rental);

            rental.DateTo = dateTo;
            var price = rental.Price;

            log.Debug($"Returning Price {price}");
            return price;
        }

        public Guid CheckoutBikesPromo(List<RentalType> rentalTypes, DateTime dateFrom)
        {
            if ((rentalTypes == null) || (rentalTypes.Count < 3) || (rentalTypes.Count > 5))
            {
                var error = $"Invalid number of rentals in CheckoutBikes";
                log.Error(error);
                throw new InvalidRentalsCountException(error);
            }

            log.Debug($"Checkout bikes: {rentalTypes.Count} bikes, from: {dateFrom}");

            var promo = new Promo();
            promo.PromoId = Guid.NewGuid();
            foreach (var rentalType in rentalTypes)
                promo.AddRental(rentalType, dateFrom, _prices);
            _promos.Add(promo);

            log.Debug($"Returning PromoId {promo.PromoId}");

            return promo.PromoId;
        }

        public decimal CheckInBikesPromo(Guid promoId, DateTime dateTo)
        {
            log.Debug($"Checkin bikes in promo: promo id = {promoId}, to: {dateTo}");

            var promo = _promos.Find(x => x.PromoId == promoId);
            if (promo == null)
            {
                var error = $"PromoId = {promoId} does not exist";
                log.Error(error);
                throw new NonExistingPromoException(error);
            }

            _promos.Remove(promo);

            decimal price = 0;
            foreach (var rental in promo.Rentals)
            {
                rental.DateTo = dateTo;
                price += rental.Price;
            }
            price = price * (decimal)0.7;

            log.Debug($"Returning Price {price}");
            return price;
        }
    }
}
