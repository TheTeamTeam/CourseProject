using CourseProject.Data;
using CourseProject.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CourseProject.Web
{ 
    public class DbConfig
    {
        public static void Intitalize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AdsHubDbContext, Configuration>());
            AdsHubDbContext.Create().Database.Initialize(true);
        }
    }
}