//--------------------------------------------------------------------------------
// <copyright file="RentalBusinessTests_FamilyPromo.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------
namespace BikeRental.Tests
{
    using System;
    using System.Collections.Generic;
    using Domain;
    using Domain.Exceptions;
    using Interfaces;
    using log4net.Config;
    using Ninject;
    using NUnit.Framework;

    /// <summary>
    /// Tests for RentalBusiness family promo
    /// </summary>
    [TestFixture]
    public sealed class RentalBusinessTests_FamilyPromo : IDisposable
    {
        /// <summary>
        /// IoC kernel
        /// </summary>
        private StandardKernel kernel;

        /// <summary>
        /// Rental business
        /// </summary>
        private IBikeRentalBusiness bis;

        /// <summary>
        /// Method used to set up the unit test
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            XmlConfigurator.Configure();

            this.kernel = new StandardKernel();
            this.kernel.Load("BikeRental.Impl.dll");
            this.bis = this.kernel.Get<IBikeRentalBusiness>();
        }

        /// <summary>
        /// Method used to dispose created objects
        /// </summary>
        public void Dispose()
        {
            this.kernel.Dispose(true);
        }

        /// <summary>
        /// Test to verify check in non existing promo
        /// </summary>
        [TestCase]
        public void TestCheckinNonExistingPromo()
        {
            Assert.Throws(
                typeof(NonExistingPromoException), 
                () =>
                {
                    this.bis.CheckInBikesPromo(Guid.Empty, DateTime.Now);
                });
        }

        /// <summary>
        /// Test to verify rental count as null
        /// </summary>
        [TestCase]
        public void TestRentalFamily_InvalidRentalCount_Null()
        {
            var dateFrom = DateTime.Now;

            Assert.Throws(
                typeof(InvalidRentalsCountException), 
                () => 
                {
                    this.bis.CheckoutBikesPromo(null, dateFrom);
                });
        }

        /// <summary>
        /// Test to verify rental count as empty
        /// </summary>
        [TestCase]
        public void TestRentalFamily_InvalidRentalCount_Empty()
        {
            var dateFrom = DateTime.Now;
            var rentals = new List<RentalType>();

            Assert.Throws(
                typeof(InvalidRentalsCountException), 
                () =>
                {
                    this.bis.CheckoutBikesPromo(rentals, dateFrom);
                });
        }

        /// <summary>
        /// Test to verify rental count as one item
        /// </summary>
        [TestCase]
        public void TestRentalFamily_InvalidRentalCount_1_Item()
        {
            var dateFrom = DateTime.Now;
            var rentals = new List<RentalType>();
            rentals.Add(RentalType.ByDay);

            Assert.Throws(
                typeof(InvalidRentalsCountException), 
                () =>
                {
                    this.bis.CheckoutBikesPromo(rentals, dateFrom);
                });
        }

        /// <summary>
        /// Test to verify rental count as two items
        /// </summary>
        [TestCase]
        public void TestRentalFamily_InvalidRentalCount_2_Items()
        {
            var dateFrom = DateTime.Now;
            var rentals = new List<RentalType>();
            rentals.Add(RentalType.ByDay);
            rentals.Add(RentalType.ByDay);

            Assert.Throws(
                typeof(InvalidRentalsCountException), 
                () =>
                {
                    this.bis.CheckoutBikesPromo(rentals, dateFrom);
                });
        }

        /// <summary>
        /// Test to verify rental count as six items
        /// </summary>
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

            Assert.Throws(
                typeof(InvalidRentalsCountException), 
                () =>
                {
                    this.bis.CheckoutBikesPromo(rentals, dateFrom);
                });
        }

        /// <summary>
        /// Test to verify three rentals by hour
        /// </summary>
        [TestCase]
        public void TestRentalFamily_3_Rentals_ByHour()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(1);
            var rentals = new List<RentalType>();
            rentals.Add(RentalType.ByHour);
            rentals.Add(RentalType.ByHour);
            rentals.Add(RentalType.ByHour);

            var promoId = this.bis.CheckoutBikesPromo(rentals, dateFrom);
            var price = this.bis.CheckInBikesPromo(promoId, dateTo);
            Assert.AreEqual(5 * 3 * 0.7, price);
        }

        /// <summary>
        /// Test to verify four rentals by hour
        /// </summary>
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

            var promoId = this.bis.CheckoutBikesPromo(rentals, dateFrom);
            var price = this.bis.CheckInBikesPromo(promoId, dateTo);
            Assert.AreEqual(20 * 4 * 0.7, price);
        }

        /// <summary>
        /// Test to verify five rentals by hour
        /// </summary>
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

            var promoId = this.bis.CheckoutBikesPromo(rentals, dateFrom);
            var price = this.bis.CheckInBikesPromo(promoId, dateTo);
            Assert.AreEqual(60 * 5 * 0.7, price);
        }

        /// <summary>
        /// Test to verify three rentals mixed
        /// </summary>
        [TestCase]
        public void TestRentalFamily_3_Rentals_Mixed()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(24);
            var rentals = new List<RentalType>();
            rentals.Add(RentalType.ByHour);
            rentals.Add(RentalType.ByDay);
            rentals.Add(RentalType.ByWeek);

            var promoId = this.bis.CheckoutBikesPromo(rentals, dateFrom);
            var price = this.bis.CheckInBikesPromo(promoId, dateTo);
            Assert.AreEqual(((24 * 5) + (1 * 20) + (1 * 60)) * 0.7, price);
        }
    }
}
