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
        public IEnumerable<Advertisement> TestSearchAds(string word, int page, int pageSize, string order, int categoryId, int cityId)
        {
            // TODO: Should it throw argument null exc
            // TODO: Query here ?
            // TODO: Dynamic order by
            // PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(Advertisement)).Find(order,true);
            var skip = (page - 1) * pageSize;
            var query = this.adsRepository.All;
            // .Where(x => x.Name.Contains(word) || x.Description.Contains(word));
            string filterExprString = "";
            //const string exp = @"(Person.Age > 3 AND Person.Weight > 50) OR Person.Age < 3";
            //var p = Expression.Parameter(typeof(Person), "Person");
            //var e = DynamicExpression.ParseLambda(new[] { p }, null, exp)

            if (!string.IsNullOrEmpty(word))
            {
                filterExprString += "(x.Name.Contains(@0) OR x.Description.Contains(@0))";
            }
            if (categoryId > 0)
            {
                // query = query.Where(x => x.CategoryId == categoryId);
                filterExprString += "AND x.CategoryId == @1";
            }

            if (cityId > 0)
            {
                // query = query.Where(x => x.CityId == cityId);
                filterExprString += "AND x.CityId == @2";
            }

            Expression<Func<Advertisement, bool>> filter;
            Expression<Func<Advertisement, bool>> filter2 = x => x.Name.Contains(word) || x.Description.Contains(word);
            Expression<Func<Advertisement, bool>> filter3 = x => x.CategoryId == categoryId;
            var body = Expression.AndAlso(filter2.Body, filter3.Body);
            var lambda = Expression.Lambda<Func<Advertisement, bool>>(body, filter2.Parameters[0]);
            if (filterExprString != "")
            {
                var p = Expression.Parameter(typeof(Advertisement), "x");
                var parameters = new object[]
                {
                word, categoryId, cityId
                };
                filter = (Expression<Func<Advertisement, bool>>)System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { p }, typeof(bool), filterExprString, parameters);
            }
            else
            {
                filter = null;
            }
            var orderP = Expression.Parameter(typeof(Advertisement), "x");

            var orderExpr = (Expression<Func<Advertisement, object>>)System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { orderP }, typeof(object), "x.@0", order);
            // var result = this.adsRepository.GetAll<object, Advertisement>(filter, orderExpr, null, skip, pageSize);
            query = query.OrderBy(order)
                .Skip(skip)
                .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<Advertisement> SearchAds(string word, int page, int pageSize, string order, int categoryId, int cityId)
        {
            var skip = (page - 1) * pageSize;
            var filterExpression = this.BuildFilterExpression(word, categoryId, cityId);

            var result = this.adsRepository.GetAll(filterExpression, order, skip, pageSize);

            return result.ToList();
        }

        public int GetAdsCount(string word, int categoryId, int cityId)
        {
            var filterExpression = this.BuildFilterExpression(word, categoryId, cityId);

            var result = this.adsRepository.GetCount(filterExpression);

            return result;
        }

        private Expression<Func<Advertisement, bool>> BuildFilterExpression(string word, int categoryId, int cityId)
        {
            // TODO: if empty   
            string filterExprStr = "(x.Name.Contains(@0) OR x.Description.Contains(@0))";

            if (categoryId > 0)
            {
                filterExprStr += " AND x.CategoryId == @1";
            }

            if (cityId > 0)
            {
                filterExprStr += " AND x.CityId == @2";
            }

            Expression<Func<Advertisement, bool>> finalExpression;
            if (filterExprStr != "")
            {
                var p = Expression.Parameter(typeof(Advertisement), "x");
                var parameters = new object[] { word, categoryId, cityId };
                finalExpression = (Expression<Func<Advertisement, bool>>)System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { p }, typeof(bool), filterExprStr, parameters);
            }
            else
            {
                finalExpression = null;
            }
            return finalExpression;
        }

        public IEnumerable<Advertisement> GetTopAds(int count)
        {
            // TODO: Should it be in another method, without the string
            var result = this.adsRepository.GetAll(null, "Name", 0, count);
            return result.ToList();
        }
    }
}
