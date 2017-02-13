using CourseProject.Models;
using System.Collections.Generic;

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
        IEnumerable<Advertisement> SearchAds(string word, int page, int pageSize, string order, int categoryId, int cityId);
        int GetAdsCount(string word, int categoryId, int cityId);
    }
}