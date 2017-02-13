using System.Collections.Generic;
using CourseProject.Models;

namespace CourseProject.Web.Models
{
    public class SearchModel
    {
        public IEnumerable<Advertisement> Advertisements { get; set; }

        public int Count { get; set; }
    }
}