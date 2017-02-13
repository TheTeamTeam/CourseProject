using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using CourseProject.Data.Repositories;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Models;
using CourseProject.Services.Contracts;

namespace CourseProject.Services
{
    public class AdvertisementsService : IAdvertisementsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Category> categoriesRepository;
        private readonly IGenericRepository<City> citiesRepository;
        private readonly IGenericRepository<Advertisement> adsRepository;

        public AdvertisementsService(
            IUnitOfWork unitOfWork,
            IGenericRepository<Category> categoriesRepository,
            IGenericRepository<City> citiesRepository,
            IGenericRepository<Advertisement> adsRepository)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null.");
            }

            if (categoriesRepository == null)
            {
                throw new ArgumentNullException("Categories repository cannot be null.");
            }

            if (citiesRepository == null)
            {
                throw new ArgumentNullException("Cities repository cannot be null.");
            }

            if (adsRepository == null)
            {
                throw new ArgumentNullException("Ads repository cannot be null.");
            }

            this.unitOfWork = unitOfWork;
            this.categoriesRepository = categoriesRepository;
            this.citiesRepository = citiesRepository;
            this.adsRepository = adsRepository;
        }

        public Advertisement GetAdById(int id)
        {
            return this.adsRepository.GetById(id);
        }

        public IEnumerable<Advertisement> GetAdvertisements()
        {
            return this.adsRepository.GetAll();
        }

        public IEnumerable<Category> GetCategories()
        {
            return this.categoriesRepository.GetAll();
        }

        public IEnumerable<City> GetCities()
        {
            return this.citiesRepository.GetAll();
        }

        public void CreateAdvertisement(Advertisement ad)
        {
            // TODO: Gaurd?
            using (this.unitOfWork)
            {
                this.adsRepository.Add(ad);
                this.unitOfWork.Commit();
            }
        }

        public void DecrementFreePlaces(Advertisement ad)
        {
            using (this.unitOfWork)
            {
                ad.Places -= 1;
                this.adsRepository.Update(ad);
                this.unitOfWork.Commit();
            }
        }


        // So not optimized....
        public IEnumerable<Advertisement> SearchAds(string word, int page, int pageSize, string order, int categoryId, int cityId)
        {
            // TODO: Should it throw argument null exc
            // TODO: Query here ?
            // TODO: Dynamic order by
            // PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(Advertisement)).Find(order,true);
            var skip = (page - 1) * pageSize;
            var query = this.adsRepository.All
                .Where(x => x.Name.Contains(word) || x.Description.Contains(word));

            if(categoryId > 0)
            {
                query = query.Where(x => x.CategoryId == categoryId);
            }

            if (cityId > 0)
            {
                query = query.Where(x => x.CityId == cityId);
            }

            query = query.OrderBy(x => x.Name)
                .Skip(skip)
                .Take(pageSize);

            return query.ToList();
        }

        public int GetAdsCount(string word, int categoryId, int cityId)
        {
            var query = this.adsRepository.All
                .Where(x => x.Name.Contains(word) || x.Description.Contains(word));

            if (categoryId > 0)
            {
                query = query.Where(x => x.CategoryId == categoryId);
            }

            if (cityId > 0)
            {
                query = query.Where(x => x.CityId == cityId);
            }

             var result = query.Count();

            return result;
        }
    }
}
