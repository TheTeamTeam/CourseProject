using System.Collections.Generic;
using CourseProject.Models;

namespace CourseProject.Mvp.Home
{
    public class HomeModel
    {
        public IEnumerable<Advertisement> TopAds { get; set; }
    }
}