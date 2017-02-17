using System;
using System.Linq;
using WebFormsMvp;
using CourseProject.Web.Views;
using CourseProject.Services.Contracts;
using CourseProject.Web.EventArguments;

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
            
            this.View.Searching += OnSearching;
            this.View.Initializing += OnInitializing;
        }

        private void OnInitializing(object sender, EventArgs e)
        {
            // TODO: should they be in a different service
            this.View.Model.Cities = this.adsService.GetCities();
            this.View.Model.Categories = this.adsService.GetCategories();
        }

        private void OnSearching(object sender, SearchEventArgs e)
        {
            // TODO: paging

            this.View.Model.Advertisements = this.adsService.SearchAds(e.SearchWord, e.OrderBy, e.CategoryId, e.CityId);

            // TODO: Optimize this - iteration
            // this.View.Model.Count = this.adsService.GetAdsCount(e.SearchWord, e.CategoryId, e.CityId);
        }
    }
}