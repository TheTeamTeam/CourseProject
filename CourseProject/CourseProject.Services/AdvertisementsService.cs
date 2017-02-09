﻿using CourseProject.Services.Contracts;
using CourseProject.Data.Repositories;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Models;
using System.Collections.Generic;
using System.Linq;

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
            // TODO: Gaurd
            this.unitOfWork = unitOfWork;
            this.categoriesRepository = categoriesRepository;
            this.citiesRepository = citiesRepository;
            this.adsRepository = adsRepository;
        }

        public Advertisement GetAdById(int id)
        {
            return this.adsRepository.GetById(id);
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
    }
}
