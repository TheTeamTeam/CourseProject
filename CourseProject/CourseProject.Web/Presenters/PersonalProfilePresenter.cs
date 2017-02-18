using System;
using WebFormsMvp;
using CourseProject.Web.Views;
using CourseProject.Web.EventArguments;
using CourseProject.Services.Contracts;
using CourseProject.Web.EventArguments.Contracts;

namespace CourseProject.Web.Presenters
{
    public class PersonalProfilePresenter : Presenter<IPersonalProfileView>
    {
        private IUsersService usersService;
        private IAdvertisementsService adsService;

        public PersonalProfilePresenter(IPersonalProfileView view, IUsersService usersService, IAdvertisementsService adsService)
            : base(view)
        {
            if (usersService == null)
            {
                throw new ArgumentNullException("Users service cannot be null.");
            }

            if (adsService == null)
            {
                throw new ArgumentNullException("Advertisement service cannot be null.");
            }

            this.usersService = usersService;
            this.adsService = adsService;

            this.View.GettingUser += this.OnGettingUser;
            this.View.RemovingSavedAd += this.OnRemovingSavedAd;
        }

        private void OnRemovingSavedAd(object sender, IdEventArgs e)
        {
            this.usersService.RemoveAdFromSaved(e.Id, this.View.Model.ProfileUser);
        }

        private void OnGettingUser(object sender, IGetUserByIdEventArgs e)
        {
            var user = this.usersService.GetUserById(e.Id);
            this.View.Model.ProfileUser = user;

            if (e.IsSeller)
            {
                this.View.Model.SellerAds = this.adsService.GetSellerAds(e.Id);
            }
        }
    }
}