using System;
using WebFormsMvp;
using CourseProject.Services.Contracts;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Views;
using CourseProject.Models;

namespace CourseProject.Web.Presenters
{
    public class AdDetailsPresenter : Presenter<IAdDetailsView>
    {
        private readonly IAdvertisementsService adsService;
        private readonly IUsersService usersService;

        public AdDetailsPresenter(IAdDetailsView view, 
                                  IAdvertisementsService adsService,
                                  IUsersService usersService)
            : base(view)
        {
            if (adsService == null)
            {
                throw new ArgumentNullException("Ads service cannot be null.");
            }

            if (usersService == null)
            {
                throw new ArgumentNullException("Users service cannot be null.");
            }

            this.adsService = adsService;
            this.usersService = usersService;

            this.View.Initializing += this.OnInitializing;
            this.View.BookAd += OnBookAd;
            this.View.SaveAd += OnSaveAd;
        }

        private void OnInitializing(object sender, AdDetailsEventArgs e)
        {
            Advertisement ad = this.adsService.GetAdById(e.AdId);
            this.View.Model.Advertisement = ad;
            this.View.Model.IsSaved = this.usersService.UserSavedAd(e.UserId, ad);
        }

        private void OnBookAd(object sender, BookAdEventArgs e)
        {
            if (!this.usersService.UserBookedAd(e.Id, e.Ad))
            {
                this.usersService.AddAdToUpcoming(e.Id, e.Ad);
                this.adsService.DecrementFreePlaces(e.Ad);
            }
            else
            {
                //TODO: already booked this ad
            }
        }

        private void OnSaveAd(object sender, SaveAdEventArgs e)
        {
            if(!this.usersService.UserSavedAd(e.Id, e.Ad))
            {
                this.usersService.AddAdToSaved(e.Id, e.Ad);
                this.View.Model.IsSaved = true;
            }
            else
            {
                //TODO: already saved this ad
            }
        }
    }
}