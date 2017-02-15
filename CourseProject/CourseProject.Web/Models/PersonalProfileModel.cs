using CourseProject.Models;
using System.Collections.Generic;

namespace CourseProject.Web.Models
{
    public class PersonalProfileModel
    {
        public User ProfileUser { get; set; }
        
        public IEnumerable<Advertisement> SellerAds { get; set; }
    }
}