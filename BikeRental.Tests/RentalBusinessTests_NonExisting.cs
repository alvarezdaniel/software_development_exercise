using BikeRental.Domain;
using BikeRental.Domain.Exceptions;
using BikeRental.Interfaces;
using Ninject;
using NUnit.Framework;
using System;

namespace BikeRental.Tests
{
    [TestFixture]
    public sealed class RentalBusinessTests_NonExisting : IDisposable
    {
        private StandardKernel _kernel;
        private IBikeRentalBusiness _bis;

        [OneTimeSetUp]
        public void SetUp()
        {
            _kernel = new StandardKernel();
            _kernel.Load("BikeRental.Impl.dll");
            _bis = _kernel.Get<IBikeRentalBusiness>();
        }

        public void Dispose()
        {
            _kernel.Dispose(true);
        }

        [TestCase]
        public void TestCheckinNonExistingBike()
        {
            Assert.Throws(typeof(NonExistingBikeException), () => 
            {
                _bis.CheckInBike(Guid.Empty, DateTime.Now);
            });
        }
    }
}
