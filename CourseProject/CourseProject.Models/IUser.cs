using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public interface IUser
    {
        string UserName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int? Age { get; set; }
        ICollection<Advertisement> SavedAds { get; set; }

        ICollection<Advertisement> UpcomingAds { get; set; }

        ClaimsIdentity GenerateUserIdentity(UserManager<User> manager);

        Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager);

        ICollection<User> FollowedUsers { get; set; }
    }
}
