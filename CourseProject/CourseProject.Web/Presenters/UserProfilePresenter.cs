using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using CourseProject.Services.Contracts;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Views;
using CourseProject.Web.Identity;
using CourseProject.Web.EventArguments.Contracts;

namespace CourseProject.Web.Presenters
{
    public class UserProfilePresenter : Presenter<IUserProfileView>
    {
        private IUsersService usersService;

        public UserProfilePresenter(IUserProfileView view, IUsersService usersService)
            : base(view)
        {
            if (usersService == null)
            {
                throw new ArgumentNullException("Users service cannot be null.");
            }

            this.usersService = usersService;

            this.View.GettingUser += OnGettingUser;
            this.View.ChangingRole += OnChangingRole;
        }

        private void OnChangingRole(object sender, RoleNameEventArgs e)
        {
            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.AddToRole(this.View.Model.ProfileUser.Id, e.RoleName);
        }

        private void OnGettingUser(object sender, GetUserByUsernameEventArgs e)
        {
            var user = this.usersService.GetUserByUsername(e.Username);
            this.View.Model.ProfileUser = user;

            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            this.View.Model.UserRoles = manager.GetRoles(user.Id);
        }
    }
}