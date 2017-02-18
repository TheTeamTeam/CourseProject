using System.Data.Entity;
using CourseProject.Data;
using CourseProject.Data.Migrations;

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