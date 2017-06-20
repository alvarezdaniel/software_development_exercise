//--------------------------------------------------------------------------------
// <copyright file="RentalBusinessTests_NonExisting.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------
namespace BikeRental.Tests
{
    using System;
    using Domain.Exceptions;
    using Interfaces;
    using Ninject;
    using NUnit.Framework;

    /// <summary>
    ///  RentalBusinessTests_NonExisting: Unit test to verify non existing bike
    /// </summary>
    [TestFixture]
    public sealed class RentalBusinessTests_NonExisting : IDisposable
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
        /// Test to verify check in non existing bike
        /// </summary>
        [TestCase]
        public void TestCheckinNonExistingBike()
        {
            Assert.Throws(
                typeof(NonExistingBikeException), 
                () => 
                {
                    this.bis.CheckInBike(Guid.Empty, DateTime.Now);
                });
        }
    }
}
