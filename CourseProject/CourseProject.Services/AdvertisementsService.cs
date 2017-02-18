using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using CourseProject.Data.Repositories;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Models;
using CourseProject.Services.Contracts;
using System.Linq.Expressions;
using System.Linq.Dynamic;

namespace CourseProject.Services
{
    public class AdvertisementsService : IAdvertisementsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Advertisement> adsRepository;

        public AdvertisementsService(
            IUnitOfWork unitOfWork,
            IGenericRepository<Advertisement> adsRepository)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("Unit of work cannot be null.");
            }          

            if (adsRepository == null)
            {
                throw new ArgumentNullException("Ads repository cannot be null.");
            }

            this.unitOfWork = unitOfWork;
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
        
        public IQueryable<Advertisement> SearchAds(string word, string order, int categoryId, int cityId)
        {
            var filterExpression = this.BuildFilterExpressions(word, categoryId, cityId);

            var orderProps = new List<string> { "Name", "Places", "Price" };
            if (!orderProps.Contains(order))
            {
                order = "Id";
            }

            bool ascending = false;
            if (order == "Name")
            {
                ascending = true;
            }

            var result = this.adsRepository.GetAllWithMultipleFilters(filterExpression, order, ascending);

            var includes = this.BuildSearchIncludes();
            result = this.adsRepository.IncludeMultiple(result, includes);

            return result;
        }

        private IEnumerable<Expression<Func<Advertisement, object>>> BuildSearchIncludes()
        {
            var includes = new List<Expression<Func<Advertisement, object>>>();

            includes.Add(x => x.City);          
            includes.Add(x => x.Category);

            return includes;
        }

        private IEnumerable<Expression<Func<Advertisement, bool>>> BuildFilterExpressions(string word, int categoryId, int cityId)
        {
            var filterExpressions = new List<Expression<Func<Advertisement, bool>>>();
            // TODO: if empty   
            if (!string.IsNullOrEmpty(word))
            {
                filterExpressions.Add(x => x.Name.Contains(word) || x.Description.Contains(word));
            }

            if (categoryId > 0)
            {
                filterExpressions.Add(x => x.CategoryId == categoryId);
            }

            if (cityId > 0)
            {
                filterExpressions.Add(x => x.CityId  == cityId);
            }

            return filterExpressions;
        }
        
        public IEnumerable<Advertisement> GetTopAds(int count)
        {
            // TODO: Should it be in another method
            //var filterExpressions = new List<Expression<Func<Advertisement, bool>>>();
            //filterExpressions.Add(x => x.ExpireDate.CompareTo(DateTime.Now) > 0);
            var result = this.adsRepository.GetAll(null, x => x.ExpireDate).Take(count);
            return result.ToList();
        }

        public IEnumerable<Advertisement> GetSellerAds(string id)
        {
            return this.adsRepository.GetAll(x => x.SellerId == id).ToList();
        }

        public void DeleteAd(int id)
        {
            using (this.unitOfWork)
            {
                var ad = this.adsRepository.GetById(id);
                this.adsRepository.Delete(ad);
                this.unitOfWork.Commit();
            }
        }

        public void UpdateAd(Advertisement ad)
        {
            using (this.unitOfWork)
            {
                this.adsRepository.Update(ad);
                unitOfWork.Commit();
            }
        }
    }
}
