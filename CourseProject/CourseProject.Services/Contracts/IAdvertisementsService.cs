using CourseProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace CourseProject.Services.Contracts
{
    public interface IAdvertisementsService
    {
        Advertisement GetAdById(int id);

        IEnumerable<Advertisement> GetAdvertisements();

        IEnumerable<Category> GetCategories();

        IEnumerable<City> GetCities();

        void CreateAdvertisement(Advertisement ad);

        void DecrementFreePlaces(Advertisement ad);

        // TODO: should ids be optional
        IQueryable<Advertisement> SearchAds(string word, string order, int categoryId, int cityId);

        IEnumerable<Advertisement> GetTopAds(int count);

        IEnumerable<Advertisement> GetSellerAds(string id);
    }
}