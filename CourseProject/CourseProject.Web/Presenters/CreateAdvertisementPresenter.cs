using CourseProject.Data.Repositories;
using CourseProject.Models;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace CourseProject.Web.Presenters
{
    public class CreateAdvertisementPresenter : Presenter<ICreateAdvertisementView>
    {
        private IGenericRepository<Advertisement> advertisementsRepository;
        private IGenericRepository<Category> categoriesRepository;
        private IGenericRepository<City> cityRepositiry;
        public CreateAdvertisementPresenter(ICreateAdvertisementView view, 
                                            IGenericRepository<Advertisement> advertisementsRepository,
                                            IGenericRepository<Category> categoriesRepository,
                                            IGenericRepository<City> cityRepositiry) 
            : base(view)
        {
            this.advertisementsRepository = advertisementsRepository;
            this.categoriesRepository = categoriesRepository;
            this.cityRepositiry = cityRepositiry;

            this.View.CreatingAdvertisement += OnCreatingAdvertisement;
        }

        private void OnCreatingAdvertisement(object sender, CreatingAdvertisementEventArgs e)
        {
            this.categoriesRepository.Add(e.Advertisement.Category);
            this.cityRepositiry.Add(e.Advertisement.City);
            this.advertisementsRepository.Add(e.Advertisement);
            this.advertisementsRepository.SaveChanges();
        }
    }
}