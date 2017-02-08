using CourseProject.Models;
using System.Collections.Generic;

namespace CourseProject.Services.Contracts
{
    public interface IAdvertisementsService
    {
        Advertisement GetAdById(int id);
        IEnumerable<Category> GetCategories();

        IEnumerable<City> GetCities();
        void CreateAdvertisement(Advertisement ad);

        void DecrementFreePlaces(Advertisement ad);
    }
}