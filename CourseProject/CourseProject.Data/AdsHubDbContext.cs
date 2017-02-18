using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using CourseProject.Models;

namespace CourseProject.Data
{
    public class AdsHubDbContext : IdentityDbContext<User>, IAdsHubDbContext
    {
        public AdsHubDbContext() : base("AdsHub")
        {
        }

        public virtual IDbSet<Advertisement> Advertisements { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public static AdsHubDbContext Create()
        {
            return new AdsHubDbContext();
        }

        // TODO: deicide how to implement method
        IDbSet<T> IAdsHubDbContext.Set<T>()
        {
            return base.Set<T>();
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(x => x.FollowedUsers).WithMany();
            modelBuilder.Entity<User>().HasMany(x => x.SavedAds).WithMany(x => x.UsersSaved);
            modelBuilder.Entity<User>().HasMany(x => x.UpcomingAds).WithMany(x => x.UsersReserved);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}