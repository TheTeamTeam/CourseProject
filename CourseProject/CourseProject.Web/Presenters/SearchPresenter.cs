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
        private readonly ICitiesService citiesService;
        private readonly ICategoriesService categoriesService;

        public SearchPresenter(
            ISearchView view,
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

            this.View.Searching += this.OnSearching;
            this.View.Initializing += this.OnInitializing;
        }

        private void OnInitializing(object sender, EventArgs e)
        {
            // TODO: should they be in a different service
            this.View.Model.Cities = this.citiesService.GetCities();
            this.View.Model.Categories = this.categoriesService.GetCategories();
        }

        private void OnSearching(object sender, SearchEventArgs e)
        {
            this.View.Model.Advertisements = this.adsService.SearchAds(e.SearchWord, e.OrderBy, e.CategoryId, e.CityId);
        }
    }
}