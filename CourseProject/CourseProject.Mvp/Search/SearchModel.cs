using System.Collections.Generic;
using System.Linq;
using CourseProject.Models;

namespace CourseProject.Mvp.Search
{
    public class SearchModel
    {
        public IQueryable<Advertisement> Advertisements { get; set; }

        public IEnumerable<City> Cities { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}