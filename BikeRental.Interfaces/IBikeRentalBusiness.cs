using BikeRental.Domain;
using System;
using System.Collections.Generic;

namespace BikeRental.Interfaces
{
    public interface IBikeRentalBusiness
    {
        Guid CheckoutBike(RentalType rentalType, DateTime dateFrom);

        decimal CheckInBike(Guid bikeId, DateTime dateTo);

        Guid CheckoutBikesPromo(List<RentalType> rentalTypes, DateTime dateFrom);

        decimal CheckInBikesPromo(Guid promoId, DateTime dateTo);
    }
}
