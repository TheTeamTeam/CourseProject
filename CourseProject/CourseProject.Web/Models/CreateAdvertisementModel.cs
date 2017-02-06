using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Web.Models
{
    public class CreateAdvertisementModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}