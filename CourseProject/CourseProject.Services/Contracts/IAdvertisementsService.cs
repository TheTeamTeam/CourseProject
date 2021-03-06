﻿using System.Collections.Generic;
using System.Linq;
using CourseProject.Models;

namespace CourseProject.Services.Contracts
{
    public interface IAdvertisementsService
    {
        Advertisement GetAdById(int id);

        IEnumerable<Advertisement> GetAdvertisements();

        void CreateAdvertisement(Advertisement ad);

        void DecrementFreePlaces(Advertisement ad);

        // TODO: should ids be optional
        IQueryable<Advertisement> SearchAds(string word, string order, int categoryId, int cityId);

        IEnumerable<Advertisement> GetTopAds(int count);

        IEnumerable<Advertisement> GetSellerAds(string id);

        void DeleteAd(int ad);

        void UpdateAd(Advertisement ad);
    }
}