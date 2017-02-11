using System;
using WebFormsMvp;
using CourseProject.Web.Views;
using CourseProject.Services.Contracts;

namespace CourseProject.Web.Presenters
{
    public class SearchPresenter : Presenter<ISearchView>
    {
        private readonly IAdvertisementsService adsService;
        public SearchPresenter(ISearchView view, IAdvertisementsService adsService) : base(view)
        {
            if(adsService == null)
            {
                throw new ArgumentNullException("Ads service cannot be null.");
            }

            this.adsService = adsService;

            this.View.Initializing += OnInit;
            this.View.Searching += OnSearching;
        }

        private void OnSearching(object sender, EventArguments.SearchEventArgs e)
        {
            // TODO: paging

            this.View.Model.Advertisements = this.adsService.SearchAds(e.SearchWord);
        }

        private void OnInit(object sender, System.EventArgs e)
        {
            // TODO: paging

            this.View.Model.Advertisements = this.adsService.GetAdvertisements();
        }
    }
}