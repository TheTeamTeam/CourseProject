using System.Collections.Generic;
using CourseProject.Models;

namespace CourseProject.Mvp.Users.UserProfile
{
    public class UserProfileModel
    {
        public User ProfileUser { get; set; }

        public bool IsSeller { get; set; }

        public IEnumerable<Advertisement> SellerAds { get; set; }
    }
}