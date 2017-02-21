using Ninject.Modules;
using Ninject.Extensions.Factory;
using CourseProject.Mvp.ImageResizing;
using ImageResizer;
using CourseProject.Mvp.Identity.Contracts;
using CourseProject.Mvp.Identity;

namespace CourseProject.Web.App_Start.NinjectModules
{
    public class CommonNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRolesProvider>().To<RolesProvider>();
            this.Bind<IImageJobFactory>().ToFactory();
            this.Bind<ImageJob>().ToSelf();
            this.Bind<IImageSaver>().To<ImageSaver>();
        }           
    }
}