//--------------------------------------------------------------------------------
// <copyright file="RentalBusinessTests_ByWeek.cs" company="Daniel Alvarez">
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
    /// Tests for RentalBusiness by week
    /// </summary>
    [TestFixture]
    public sealed class RentalBusinessTests_ByWeek : IDisposable
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
        /// Test to verify rental by week (1 day change 1 week)
        /// </summary>
        [TestCase]
        public void TestRentalByWeek_1Day_Charge_1Week()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddDays(1);

            var bikeId = this.bis.CheckoutBike(RentalType.ByWeek, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(60.0, price);
        }

        /// <summary>
        /// Test to verify rental by week (7 day change 1 week)
        /// </summary>
        [TestCase]
        public void TestRentalByWeek_7Day_Charge_1Week()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddDays(7);

            var bikeId = this.bis.CheckoutBike(RentalType.ByWeek, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(60.0, price);
        }

        /// <summary>
        /// Test to verify rental by week (9 day change 2 weeks)
        /// </summary>
        [TestCase]
        public void TestRentalByWeek_9Day_Charge_2Weeks()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddDays(9);

            var bikeId = this.bis.CheckoutBike(RentalType.ByWeek, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(120.0, price);
        }

        /// <summary>
        /// Test to verify rental by week (14 day change 2 weeks)
        /// </summary>
        [TestCase]
        public void TestRentalByWeek_14Day_Charge_2Weeks()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddDays(14);

            var bikeId = this.bis.CheckoutBike(RentalType.ByWeek, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(120.0, price);
        }
    }
}
