using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using CourseProject.Services.Contracts;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Views;
using CourseProject.Mvp.Identity;

namespace CourseProject.Web.Presenters
{
    public class UserProfilePresenter : Presenter<IUserProfileView>
    {
        private IUsersService usersService;
        private IAdvertisementsService adsService;

        public UserProfilePresenter(IUserProfileView view, IUsersService usersService, IAdvertisementsService adsService)
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
        }

        private void OnGettingUser(object sender, GetUserByUsernameEventArgs e)
        {
            var user = this.usersService.GetUserByUsername(e.Username);

            if (user == null)
            {
                this.View.Server.Transfer("~/ErrorPages/404.aspx");
                return;
            }

            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roles = manager.GetRoles(user.Id);

            var isSeller = roles.Contains("Seller");

            // Only admins can view all users profiles. Regular users can view only profile of sellers
            if (!this.View.User.IsInRole("Admin") && !isSeller)
            {
                this.View.Server.Transfer("~/ErrorPages/401.aspx");
                return;
            }

            this.View.Model.ProfileUser = user;
            this.View.Model.IsSeller = isSeller;
            
            if (isSeller)
            {
                this.View.Model.SellerAds = this.adsService.GetSellerAds(user.Id);
            }
        }
    }
}