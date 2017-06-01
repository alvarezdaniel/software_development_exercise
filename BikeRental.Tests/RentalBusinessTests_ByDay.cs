using BikeRental.Domain;
using BikeRental.Interfaces;
using log4net;
using log4net.Config;
using Ninject;
using NUnit.Framework;
using System;

namespace BikeRental.Tests
{
    [TestFixture]
    public sealed class RentalBusinessTests_ByDay : IDisposable
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
        public void TestRentalByDay_12Hours_Charge_1Day()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(12);

            var bikeId = _bis.CheckoutBike(RentalType.ByDay, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(20.0, price);
        }

        [TestCase]
        public void TestRentalByHour_1Day_Charge_1Day()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(24);

            var bikeId = _bis.CheckoutBike(RentalType.ByDay, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(20.0, price);
        }

        [TestCase]
        public void TestRentalByHour_36Hours_Charge_2Days()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(36);

            var bikeId = _bis.CheckoutBike(RentalType.ByDay, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(40.0, price);
        }

        [TestCase]
        public void TestRentalByHour_48Hours_Charge_2Days()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(48);

            var bikeId = _bis.CheckoutBike(RentalType.ByDay, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(40.0, price);
        }

        [TestCase]
        public void TestRentalByHour_60Hours_Charge_3Days()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(60);

            var bikeId = _bis.CheckoutBike(RentalType.ByDay, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(60.0, price);
        }

        [TestCase]
        public void TestRentalByHour_72Hours_Charge_3Days()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(72);

            var bikeId = _bis.CheckoutBike(RentalType.ByDay, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(60.0, price);
        }
    }
}
