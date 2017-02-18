using System;
using WebFormsMvp;
using CourseProject.Services.Contracts;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Views;

namespace CourseProject.Web.Presenters
{
    public class HomePresenter : Presenter<IHomeView>
    {
        private readonly IAdvertisementsService adsService;

        public HomePresenter(IHomeView view, IAdvertisementsService adsService) : base(view)
        {
            if (adsService == null)
            {
                throw new ArgumentNullException("Advertisements service cannot be null.");
            }

            this.adsService = adsService;

            this.View.Initializing += this.OnInitializing;
        }

        private void OnInitializing(object sender, CountEventArgs e)
        {
            this.View.Model.TopAds = this.adsService.GetTopAds(e.Count);
        }
    }
}