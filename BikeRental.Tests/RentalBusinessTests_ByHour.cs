using BikeRental.Domain;
using BikeRental.Interfaces;
using log4net;
using log4net.Config;
using Ninject;
using NUnit.Framework;
using System;
using System.Reflection;

namespace BikeRental.Tests
{
    [TestFixture]
    public sealed class RentalBusinessTests_ByHour : IDisposable
    {
        private StandardKernel _kernel;
        private IBikeRentalBusiness _bis;

        [OneTimeSetUp]
        public void SetUp()
        {
            XmlConfigurator.Configure();

            _kernel = new StandardKernel();
            _kernel.Load("BikeRental.Impl.dll");
            _bis = _kernel.Get<IBikeRentalBusiness>();
        }

        public void Dispose()
        {
            _kernel.Dispose(true);
        }

        [TestCase]
        public void TestRentalByHour_30Minutes_Charge_1Hour()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddMinutes(30);

            var bikeId = _bis.CheckoutBike(RentalType.ByHour, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(5.0, price);
        }

        [TestCase]
        public void TestRentalByHour_1Hour_Charge_1Hour()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(1);

            var bikeId = _bis.CheckoutBike(RentalType.ByHour, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(5.0, price);
        }

        [TestCase]
        public void TestRentalByHour_90Minutes_Charge_2Hours()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddMinutes(90);

            var bikeId = _bis.CheckoutBike(RentalType.ByHour, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(10.0, price);
        }

        [TestCase]
        public void TestRentalByHour_119Minutes_Charge_2Hours()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddMinutes(119);

            var bikeId = _bis.CheckoutBike(RentalType.ByHour, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(10.0, price);
        }

        [TestCase]
        public void TestRentalByHour_120Minutes_Charge_2Hours()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddMinutes(120);

            var bikeId = _bis.CheckoutBike(RentalType.ByHour, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(10.0, price);
        }

        [TestCase]
        public void TestRentalByHour_150Minutes_Charge_3Hours()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddMinutes(150);

            var bikeId = _bis.CheckoutBike(RentalType.ByHour, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(15.0, price);
        }
    }
}
