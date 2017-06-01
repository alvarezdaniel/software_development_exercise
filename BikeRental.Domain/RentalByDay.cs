
using System;

namespace BikeRental.Domain
{
    public class RentalByDay : Rental
    {
        public RentalByDay()
        {
            RentalType = RentalType.ByDay;
        }

        public override decimal Price
        {
            get
            {
                var span = DateTo - DateFrom;

                var days = Math.Truncate(span.TotalDays);
                if (span.Hours > 0)
                    days++;

                return (decimal)days * Prices.ByDay;
            }
        }
    }
}
