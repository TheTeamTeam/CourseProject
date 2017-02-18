using System.Collections.Generic;
using CourseProject.Models;

namespace CourseProject.Mvp.Users.PersonalProfile
{
    public class PersonalProfileModel
    {
        public User ProfileUser { get; set; }
        
        public IEnumerable<Advertisement> SellerAds { get; set; }
    }
}