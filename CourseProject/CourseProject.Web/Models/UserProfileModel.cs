using System.Collections.Generic;
using CourseProject.Models;

namespace CourseProject.Web.Models
{
    public class UserProfileModel
    {
        public User ProfileUser { get; set; }

        public IEnumerable<string> UserRoles { get; set; }
    }
}