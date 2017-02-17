using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using CourseProject.Services.Contracts;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Views;
using CourseProject.Web.Identity;

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
            this.View.AddingRole += this.OnAddingRole;
            this.View.RemovingRole += this.OnRemovingRole;
        }

        private void OnAddingRole(object sender, RoleNameEventArgs e)
        {
            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.AddToRole(this.View.Model.ProfileUser.Id, e.RoleName);
            if(e.RoleName == "Admin")
            {
                this.View.Model.IsAdmin = true;
            }
            else
            {
                this.View.Model.IsSeller = true;
            }
        }

        private void OnRemovingRole(object sender, RoleNameEventArgs e)
        {
            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.RemoveFromRole(this.View.Model.ProfileUser.Id, e.RoleName);
            if (e.RoleName == "Admin")
            {
                this.View.Model.IsAdmin = false;
            }
            else
            {
                this.View.Model.IsSeller = false;
            }
        }

        private void OnGettingUser(object sender, GetUserByUsernameEventArgs e)
        {
            var user = this.usersService.GetUserByUsername(e.Username);
            this.View.Model.ProfileUser = user;

            if (user != null)
            {
                var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var roles = manager.GetRoles(user.Id);

                this.View.Model.IsAdmin = roles.Contains("Admin");
                var isSeller = roles.Contains("Seller");
                this.View.Model.IsSeller = isSeller;

                if (isSeller)
                {
                    this.View.Model.SellerAds = this.adsService.GetSellerAds(user.Id);
                }
            }

            
        }
    }
}