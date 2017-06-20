//--------------------------------------------------------------------------------
// <copyright file="BikeRentalIoCModule.cs" company="Daniel Alvarez">
//   Copyright (c) Daniel Alvarez. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------

namespace BikeRental.Impl
{
    using Interfaces;
    using Ninject.Modules;

    /// <summary>
    /// Bike rental IoC module
    /// </summary>
    public class BikeRentalIoCModule : NinjectModule
    {
        /// <summary>
        /// Loads the injected dependencies
        /// </summary>
        public override void Load()
        {
            Bind<IBikeRentalBusiness>().To<BikeRentalBusiness>().InSingletonScope();
        }
    }
}
