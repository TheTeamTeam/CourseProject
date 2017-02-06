using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CourseProject.Models;

namespace CourseProject.Data
{
    public interface IAdsHubDbContext
    {
        IDbSet<Advertisement> Advertisements { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<City> Cities { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}