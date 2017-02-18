using System.Collections.Generic;
using CourseProject.Models;

namespace CourseProject.Mvp.CreateAdvertisement
{
    public class CreateAdvertisementModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}