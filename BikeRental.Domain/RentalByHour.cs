
using System;

namespace BikeRental.Domain
{
    public class RentalByHour : Rental
    {
        public RentalByHour()
        {
            RentalType = RentalType.ByHour;
        }

        public override decimal Price
        {
            get
            {
                var span = DateTo - DateFrom;

                var hours = Math.Truncate(span.TotalHours);
                if (span.Minutes > 0)
                    hours++;

                return (decimal)hours * Prices.ByHour;
            }
        }
    }
}
