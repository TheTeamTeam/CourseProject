using System.Collections.Generic;
using CourseProject.Models;

namespace CourseProject.Web.Models
{
    public class CreateAdvertisementModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}