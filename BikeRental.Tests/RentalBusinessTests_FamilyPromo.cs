using BikeRental.Domain;
using BikeRental.Domain.Exceptions;
using BikeRental.Interfaces;
using log4net;
using log4net.Config;
using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BikeRental.Tests
{
    [TestFixture]
    public sealed class RentalBusinessTests_FamilyPromo : IDisposable
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
        public void TestCheckinNonExistingPromo()
        {
            Assert.Throws(typeof(NonExistingPromoException), () =>
            {
                _bis.CheckInBikesPromo(Guid.Empty, DateTime.Now);
            });
        }

        [TestCase]
        public void TestRentalFamily_InvalidRentalCount_Null()
        {
            var dateFrom = DateTime.Now;

            Assert.Throws(typeof(InvalidRentalsCountException), () => 
            {
                _bis.CheckoutBikesPromo(null, dateFrom);
            });
        }

        [TestCase]
        public void TestRentalFamily_InvalidRentalCount_Empty()
        {
            var dateFrom = DateTime.Now;
            var rentals = new List<RentalType>();

            Assert.Throws(typeof(InvalidRentalsCountException), () =>
            {
                _bis.CheckoutBikesPromo(rentals, dateFrom);
            });
        }

        [TestCase]
        public void TestRentalFamily_InvalidRentalCount_1_Item()
        {
            var dateFrom = DateTime.Now;
            var rentals = new List<RentalType>();
            rentals.Add(RentalType.ByDay);

            Assert.Throws(typeof(InvalidRentalsCountException), () =>
            {
                _bis.CheckoutBikesPromo(rentals, dateFrom);
            });
        }

        [TestCase]
        public void TestRentalFamily_InvalidRentalCount_2_Items()
        {
            var dateFrom = DateTime.Now;
            var rentals = new List<RentalType>();
            rentals.Add(RentalType.ByDay);
            rentals.Add(RentalType.ByDay);

            Assert.Throws(typeof(InvalidRentalsCountException), () =>
            {
                _bis.CheckoutBikesPromo(rentals, dateFrom);
            });
        }

        [TestCase]
        public void TestRentalFamily_InvalidRentalCount_6_Items()
        {
            var dateFrom = DateTime.Now;
            var rentals = new List<RentalType>();
            rentals.Add(RentalType.ByDay);
            rentals.Add(RentalType.ByDay);
            rentals.Add(RentalType.ByDay);
            rentals.Add(RentalType.ByDay);
            rentals.Add(RentalType.ByDay);
            rentals.Add(RentalType.ByDay);

            Assert.Throws(typeof(InvalidRentalsCountException), () =>
            {
                _bis.CheckoutBikesPromo(rentals, dateFrom);
            });
        }

        [TestCase]
        public void TestRentalFamily_3_Rentals_ByHour()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(1);
            var rentals = new List<RentalType>();
            rentals.Add(RentalType.ByHour);
            rentals.Add(RentalType.ByHour);
            rentals.Add(RentalType.ByHour);

            var promoId = _bis.CheckoutBikesPromo(rentals, dateFrom);
            var price = _bis.CheckInBikesPromo(promoId, dateTo);
            Assert.AreEqual(5 * 3 * 0.7, price);
        }

        [TestCase]
        public void TestRentalFamily_4_Rentals_ByDay()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddDays(1);
            var rentals = new List<RentalType>();
            rentals.Add(RentalType.ByDay);
            rentals.Add(RentalType.ByDay);
            rentals.Add(RentalType.ByDay);
            rentals.Add(RentalType.ByDay);

            var promoId = _bis.CheckoutBikesPromo(rentals, dateFrom);
            var price = _bis.CheckInBikesPromo(promoId, dateTo);
            Assert.AreEqual(20 * 4 * 0.7, price);
        }

        [TestCase]
        public void TestRentalFamily_5_Rentals_ByWeek()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddDays(7);
            var rentals = new List<RentalType>();
            rentals.Add(RentalType.ByWeek);
            rentals.Add(RentalType.ByWeek);
            rentals.Add(RentalType.ByWeek);
            rentals.Add(RentalType.ByWeek);
            rentals.Add(RentalType.ByWeek);

            var promoId = _bis.CheckoutBikesPromo(rentals, dateFrom);
            var price = _bis.CheckInBikesPromo(promoId, dateTo);
            Assert.AreEqual(60 * 5 * 0.7, price);
        }

        [TestCase]
        public void TestRentalFamily_3_Rentals_Mixed()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(24);
            var rentals = new List<RentalType>();
            rentals.Add(RentalType.ByHour);
            rentals.Add(RentalType.ByDay);
            rentals.Add(RentalType.ByWeek);

            var promoId = _bis.CheckoutBikesPromo(rentals, dateFrom);
            var price = _bis.CheckInBikesPromo(promoId, dateTo);
            Assert.AreEqual(((24*5) + (1*20) + (1*60)) * 0.7, price);
        }

    }
}
