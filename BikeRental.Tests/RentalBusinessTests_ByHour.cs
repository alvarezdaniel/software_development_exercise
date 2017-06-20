//--------------------------------------------------------------------------------
// <copyright file="RentalBusinessTests_ByHour.cs" company="Daniel Alvarez">
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
    /// Tests for RentalBusiness by hour
    /// </summary>
    [TestFixture]
    public sealed class RentalBusinessTests_ByHour : IDisposable
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
        /// Test to verify rental by hour (30 minutes change 1 hour)
        /// </summary>
        [TestCase]
        public void TestRentalByHour_30Minutes_Charge_1Hour()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddMinutes(30);

            var bikeId = this.bis.CheckoutBike(RentalType.ByHour, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(5.0, price);
        }

        /// <summary>
        /// Test to verify rental by hour (1 hour change 1 hour)
        /// </summary>
        [TestCase]
        public void TestRentalByHour_1Hour_Charge_1Hour()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddHours(1);

            var bikeId = this.bis.CheckoutBike(RentalType.ByHour, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(5.0, price);
        }

        /// <summary>
        /// Test to verify rental by hour (90 minutes change 2 hours)
        /// </summary>
        [TestCase]
        public void TestRentalByHour_90Minutes_Charge_2Hours()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddMinutes(90);

            var bikeId = this.bis.CheckoutBike(RentalType.ByHour, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(10.0, price);
        }

        /// <summary>
        /// Test to verify rental by hour (119 minutes change 2 hours)
        /// </summary>
        [TestCase]
        public void TestRentalByHour_119Minutes_Charge_2Hours()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddMinutes(119);

            var bikeId = this.bis.CheckoutBike(RentalType.ByHour, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(10.0, price);
        }

        /// <summary>
        /// Test to verify rental by hour (120 minutes change 2 hours)
        /// </summary>
        [TestCase]
        public void TestRentalByHour_120Minutes_Charge_2Hours()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddMinutes(120);

            var bikeId = this.bis.CheckoutBike(RentalType.ByHour, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(10.0, price);
        }

        /// <summary>
        /// Test to verify rental by hour (150 minutes change 3 hours)
        /// </summary>
        [TestCase]
        public void TestRentalByHour_150Minutes_Charge_3Hours()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddMinutes(150);

            var bikeId = this.bis.CheckoutBike(RentalType.ByHour, dateFrom);
            var price = this.bis.CheckInBike(bikeId, dateTo);
            Assert.AreEqual(15.0, price);
        }
    }
}
