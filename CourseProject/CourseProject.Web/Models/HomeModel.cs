using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Web.Models
{
    public class HomeModel
    {
        public IEnumerable<Advertisement> TopAds { get; set; }
    }
}