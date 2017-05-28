using BikeRental.Core;
using NUnit.Framework;

namespace BikeRental.Tests
{
    [TestFixture]
    public class RentalBusinessTests
    {
        [TestCase]
        public void Test1()
        {
            var bis = new BikeRentalBusiness();

            Assert.AreEqual(true, true);
        }
    }
}
