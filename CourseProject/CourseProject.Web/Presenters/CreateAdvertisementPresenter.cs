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

        public CreateAdvertisementPresenter(ICreateAdvertisementView view, IAdvertisementsService adsService) 
            : base(view)
        {
            if (adsService == null)
            {
                throw new ArgumentNullException("Ads service cannot be null.");
            }

            this.adsService = adsService;

            this.View.MyInit += OnInit;
            this.View.CreatingAdvertisement += OnCreatingAdvertisement;
        }

        private void OnInit(object sender, System.EventArgs e)
        {
            this.View.Model.Categories = this.adsService.GetCategories();
            this.View.Model.Cities = this.adsService.GetCities();
        }

        private void OnCreatingAdvertisement(object sender, CreatingAdvertisementEventArgs e)
        {
            this.adsService.CreateAdvertisement(e.Advertisement);
        }
    }
}