using BikeRental.Interfaces;
using Ninject.Modules;

namespace BikeRental.Impl
{
    public class BikeRentalIoCModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBikeRentalBusiness>().To<BikeRentalBusiness>().InSingletonScope();
        }
    }
}
