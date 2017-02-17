using System.Collections.Generic;
using CourseProject.Models;
using System.Linq;

namespace CourseProject.Web.Models
{
    public class SearchModel
    {
        public IQueryable<Advertisement> Advertisements { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public int Count { get; set; }
    }
}