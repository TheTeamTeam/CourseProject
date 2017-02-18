using System;
using System.Collections.Generic;
using CourseProject.Data.Repositories;
using CourseProject.Models;
using CourseProject.Services.Contracts;

namespace CourseProject.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly IGenericRepository<City> citiesRepository;

        public CitiesService(IGenericRepository<City> citiesRepository)
        {
            if (citiesRepository == null)
            {
                throw new ArgumentNullException("Cities repository cannot be null.");
            }

            this.citiesRepository = citiesRepository;
        }

        public IEnumerable<City> GetCities()
        {
            return this.citiesRepository.GetAll();
        }
    }
}
