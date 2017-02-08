using CourseProject.Web.Models;
using CourseProject.Web.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using CourseProject.Web.EventArguments;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;
using WebFormsMvp;

namespace CourseProject.Web.Users
{
    public partial class UserProfile : MvpPage<UserProfileModel>, IUserProfileView
    {
        public event EventHandler<GetUserByUsernameEventArgs> GettingUser;
        public event EventHandler<RoleNameEventArgs> ChangingRole;

        protected void Page_Load(object sender, EventArgs e)
        {
            var userNameParam = this.Page.RouteData.Values["username"];
            if (userNameParam == null)
            {
                // TODO: redirect to not found
                this.Response.Redirect("~/");
            }

            var username = userNameParam.ToString();
            this.GettingUser?.Invoke(this, new GetUserByUsernameEventArgs(username, this.Context));

            if (this.Model.ProfileUser == null)
            {
                // TODO: redirect to not found
                this.Response.Redirect("~/");
            }

            // TODO: allow for all users and check for sellers

            // Only admins can view all users profiles. Regular users can view only profile of sellers
            if (!this.User.IsInRole("Admin") && !this.Model.UserRoles.Contains("Seller"))
            {
                this.Response.Redirect("~/");
            }
        }

        protected void MakeSellerBtn_Click(object sender, EventArgs e)
        {
            this.ChangingRole?.Invoke(this, new RoleNameEventArgs("Seller", this.Context));
            (sender as Button).Visible = false;
        }

        protected void MakeAdminBtn_Click(object sender, EventArgs e)
        {
            this.ChangingRole?.Invoke(this, new RoleNameEventArgs("Admin", this.Context));
            (sender as Button).Visible = false;
        }
    }
}