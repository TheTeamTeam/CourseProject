using System;
using System.Collections.Generic;
using CourseProject.Data.Repositories;
using CourseProject.Models;
using CourseProject.Services.Contracts;

namespace CourseProject.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IGenericRepository<Category> categoriesRepository;

        public CategoriesService(IGenericRepository<Category> categoriesRepository)
        {
            if (categoriesRepository == null)
            {
                throw new ArgumentNullException("Categories repository cannot be null.");
            }

            this.categoriesRepository = categoriesRepository;
        }
        
        public IEnumerable<Category> GetCategories()
        {
            return this.categoriesRepository.GetAll();
        }
    }
}
