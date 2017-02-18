using Ninject.Modules;
using Ninject.Web.Common;
using CourseProject.Data;
using CourseProject.Data.Repositories;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Services;
using CourseProject.Services.Contracts;

namespace CourseProject.Web.App_Start.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            // TODO: Bind default interfaces

            this.Bind<IAdsHubDbContext>().To<AdsHubDbContext>().InRequestScope();
            this.Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>)).InRequestScope();
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            this.Bind<IAdvertisementsService>().To<AdvertisementsService>().InRequestScope();
            this.Bind<IUsersService>().To<UsersService>().InRequestScope();
            this.Bind<ICategoriesService>().To<CategoriesService>().InRequestScope();
            this.Bind<ICitiesService>().To<CitiesService>().InRequestScope();
        }
    }
}