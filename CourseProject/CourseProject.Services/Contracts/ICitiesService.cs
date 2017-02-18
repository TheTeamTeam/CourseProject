using System.Collections.Generic;
using CourseProject.Models;

namespace CourseProject.Services.Contracts
{
    public interface ICitiesService
    {
        IEnumerable<City> GetCities();
    }
}