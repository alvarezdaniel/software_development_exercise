using System;

namespace BikeRental.Domain
{
    public abstract class Rental
    {
        public Guid BikeId { get; set; }

        protected RentalType RentalType { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public abstract decimal Price { get; }

        public Prices Prices { get; set; }

        public static Rental ByType(RentalType rentalType)
        {
            switch (rentalType)
            {
                case RentalType.ByHour:
                        return new RentalByHour(); 
                case RentalType.ByDay:
                    return new RentalByDay();
                case RentalType.ByWeek: 
                default:
                     return new RentalByWeek();
            }
        }
    }
}
