using WebFormsMvp;
using CourseProject.Data.Repositories;
using CourseProject.Models;
using CourseProject.Services.Contracts;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Views;
using System;

namespace CourseProject.Web.Presenters
{
    public class CreateAdvertisementPresenter : Presenter<ICreateAdvertisementView>
    {
        private IAdvertisementsService adsService;
        private readonly ICitiesService citiesService;
        private readonly ICategoriesService categoriesService;

        public CreateAdvertisementPresenter(
            ICreateAdvertisementView view, 
            IAdvertisementsService adsService,
            ICitiesService citiesService,
            ICategoriesService categoriesService) 
            : base(view)
        {
            if (adsService == null)
            {
                throw new ArgumentNullException("Ads service cannot be null.");
            }

            if (citiesService == null)
            {
                throw new ArgumentNullException("Cities service cannot be null.");
            }

            if (categoriesService == null)
            {
                throw new ArgumentNullException("Categories service cannot be null.");
            }

            this.adsService = adsService;
            this.citiesService = citiesService;
            this.categoriesService = categoriesService;

            this.View.MyInit += OnInit;
            this.View.CreatingAdvertisement += OnCreatingAdvertisement;
        }

        private void OnInit(object sender, EventArgs e)
        {
            this.View.Model.Categories = this.categoriesService.GetCategories();
            this.View.Model.Cities = this.citiesService.GetCities();
        }

        private void OnCreatingAdvertisement(object sender, CreatingAdvertisementEventArgs e)
        {
            this.adsService.CreateAdvertisement(e.Advertisement);
        }
    }
}