using CourseProject.Models;
using System.Collections.Generic;

namespace CourseProject.Services.Contracts
{
    public interface IAdvertisementsService
    {
        IEnumerable<Category> GetCategories();

        IEnumerable<City> GetCities();
        void CreateAdvertisement(Advertisement ad);
    }
}