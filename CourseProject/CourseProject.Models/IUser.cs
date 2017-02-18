using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace CourseProject.Models
{
    // TODO: Delete interface if not used
    public interface IUser
    {
        string UserName { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        int? Age { get; set; }

        ICollection<Advertisement> SavedAds { get; set; }

        ICollection<Advertisement> UpcomingAds { get; set; }

        ICollection<User> FollowedUsers { get; set; }

        ClaimsIdentity GenerateUserIdentity(UserManager<User> manager);

        Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager);
    }
}
