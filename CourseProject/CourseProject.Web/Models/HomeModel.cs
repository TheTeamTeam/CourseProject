using System.Collections.Generic;
using CourseProject.Models;

namespace CourseProject.Web.Models
{
    public class HomeModel
    {
        public IEnumerable<Advertisement> TopAds { get; set; }
    }
}