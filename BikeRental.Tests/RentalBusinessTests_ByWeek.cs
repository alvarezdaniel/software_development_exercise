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
    public sealed class RentalBusinessTests_ByWeek : IDisposable
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
        public void TestRentalByWeek_1Day_Charge_1Week()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddDays(1);

            var bikeId = _bis.CheckoutBike(RentalType.ByWeek, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(60.0, price);
        }

        [TestCase]
        public void TestRentalByWeek_7Day_Charge_1Week()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddDays(7);

            var bikeId = _bis.CheckoutBike(RentalType.ByWeek, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(60.0, price);
        }

        [TestCase]
        public void TestRentalByWeek_9Day_Charge_2Week()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddDays(9);

            var bikeId = _bis.CheckoutBike(RentalType.ByWeek, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(120.0, price);
        }

        [TestCase]
        public void TestRentalByWeek_14Day_Charge_2Week()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddDays(14);

            var bikeId = _bis.CheckoutBike(RentalType.ByWeek, dateFrom);
            var price = _bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(120.0, price);
        }
    }
}
