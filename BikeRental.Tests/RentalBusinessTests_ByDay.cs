//--------------------------------------------------------------------------------
// <copyright file="RentalBusinessTests_BydAY.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------
namespace BikeRental.Tests
{
    using System;
    using Domain;
    using Interfaces;
    using log4net.Config;
    using Ninject;
    using NUnit.Framework;

    /// <summary>
    /// Tests for RentalBusiness by day
    /// </summary>
    [TestFixture]
    public sealed class RentalBusinessTests_ByDay : IDisposable
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
        /// Test to verify rental by day (12 hours change 1 day)
        /// </summary>
        [TestCase]
        public void TestRentalByDay_12Hours_Charge_1Day()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(12);

            var bikeId = this.bis.CheckoutBike(RentalType.ByDay, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(20.0, price);
        }

        /// <summary>
        /// Test to verify rental by day (24 hours change 1 day)
        /// </summary>
        [TestCase]
        public void TestRentalByHour_24Hours_Charge_1Day()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(24);

            var bikeId = this.bis.CheckoutBike(RentalType.ByDay, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(20.0, price);
        }

        /// <summary>
        /// Test to verify rental by day (36 hours change 2 days)
        /// </summary>
        [TestCase]
        public void TestRentalByHour_36Hours_Charge_2Days()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(36);

            var bikeId = this.bis.CheckoutBike(RentalType.ByDay, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(40.0, price);
        }

        /// <summary>
        /// Test to verify rental by day (48 hours change 2 days)
        /// </summary>
        [TestCase]
        public void TestRentalByHour_48Hours_Charge_2Days()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(48);

            var bikeId = this.bis.CheckoutBike(RentalType.ByDay, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(40.0, price);
        }

        /// <summary>
        /// Test to verify rental by day (60 hours change 3 days)
        /// </summary>
        [TestCase]
        public void TestRentalByHour_60Hours_Charge_3Days()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(60);

            var bikeId = this.bis.CheckoutBike(RentalType.ByDay, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(60.0, price);
        }

        /// <summary>
        /// Test to verify rental by day (72 hours change 3 days)
        /// </summary>
        [TestCase]
        public void TestRentalByHour_72Hours_Charge_3Days()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(72);

            var bikeId = this.bis.CheckoutBike(RentalType.ByDay, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(60.0, price);
        }
    }
}
