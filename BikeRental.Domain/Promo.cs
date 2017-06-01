
using System;
using System.Collections.Generic;

namespace BikeRental.Domain
{
    public class Promo
    {
        public Guid PromoId { get; set; }

        public List<Rental> Rentals { get; private set; }

        public Promo()
        {
            Rentals = new List<Rental>();
        }

        public void AddRental(RentalType rentalType, DateTime dateFrom, Prices prices)
        {
            var rental = Rental.ByType(rentalType);
            rental.Prices = prices;
            rental.BikeId = Guid.NewGuid();
            rental.DateFrom = dateFrom;
            Rentals.Add(rental);
        }
    }
}
