using System;
using WebFormsMvp;
using CourseProject.Services.Contracts;
using CourseProject.Models;
using CourseProject.Mvp.CommonEventArguments;

namespace CourseProject.Mvp.AdDetails
{
    public class AdDetailsPresenter : Presenter<IAdDetailsView>
    {
        private readonly IAdvertisementsService adsService;
        private readonly IUsersService usersService;

        public AdDetailsPresenter(
            IAdDetailsView view,
            IAdvertisementsService adsService,
            IUsersService usersService)
            : base(view)
        {
            if (adsService == null)
            {
                throw new ArgumentNullException("Advertisements service cannot be null.");
            }

            if (usersService == null)
            {
                throw new ArgumentNullException("Users service cannot be null.");
            }

            this.adsService = adsService;
            this.usersService = usersService;

            this.View.Initializing += this.OnInitializing;
            this.View.BookAd += this.OnBookAd;
            this.View.SaveAd += this.OnSaveAd;
            this.View.DeleteAd += this.OnDeleteAd;
            this.View.UpdateAd += this.OnUpdateAd;
        }

        private void OnUpdateAd(object sender, IdEventArgs e)
        {
            Advertisement ad = this.adsService.GetAdById(e.Id);
            if (ad == null)
            {
                // The item wasn't found
                this.View.ModelState.AddModelError("", string.Format("Item with id {0} was not found", e.Id));
                return;
            }

            this.View.TryUpdateModel(ad);
            if (this.View.ModelState.IsValid)
            {
                this.adsService.UpdateAd(ad);
            }
        }

        private void OnDeleteAd(object sender, IdEventArgs e)
        {
            this.adsService.DeleteAd(e.Id);
            this.View.Response.Redirect("~/");
        }

        private void OnInitializing(object sender, AdDetailsEventArgs e)
        {
            Advertisement ad = this.adsService.GetAdById(e.AdId);
            this.View.Model.Advertisement = ad;

            this.View.Model.BookButtonVisible = e.UserId != null ? !this.usersService.UserBookedAd(e.UserId, ad) : false;
            this.View.Model.SaveButtonVisible = e.UserId != null ? !this.usersService.UserSavedAd(e.UserId, ad) : false;
        }

        private void OnBookAd(object sender, BookAdEventArgs e)
        {
            if (!this.usersService.UserBookedAd(e.Id, e.Ad))
            {
                this.usersService.AddAdToUpcoming(e.Id, e.Ad);
                this.adsService.DecrementFreePlaces(e.Ad);
                this.View.Model.BookButtonVisible = false;
            }
        }

        private void OnSaveAd(object sender, SaveAdEventArgs e)
        {
            if (!this.usersService.UserSavedAd(e.Id, e.Ad))
            {
                this.usersService.AddAdToSaved(e.Id, e.Ad);
                this.View.Model.SaveButtonVisible = false;
            }
        }
    }
}