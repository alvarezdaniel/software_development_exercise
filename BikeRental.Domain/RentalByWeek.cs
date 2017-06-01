
using System;

namespace BikeRental.Domain
{
    public class RentalByWeek : Rental
    {
        public RentalByWeek()
        {
            RentalType = RentalType.ByWeek;
        }

        public override decimal Price
        {
            get
            {
                var span = DateTo - DateFrom;

                double weeks = Math.Truncate(span.TotalDays) / 7;

                var days = weeks - Math.Truncate(weeks);
                if (days > 0)
                    weeks++;

                return ((decimal)Math.Truncate(weeks) * Prices.ByWeek);
            }
        }
    }
}
