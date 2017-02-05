using CourseProject.Data;
using CourseProject.Data.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Web.App_Start.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAdsHubDbContext>().To<AdsHubDbContext>().InRequestScope();
            this.Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>)).InRequestScope();
        }
    }
}