using System;
using Microsoft.AspNet.Identity;
using WebFormsMvp.Web;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;
using CourseProject.Web.Views;

namespace CourseProject.Web.Users
{
    public partial class UserProfile : MvpPage<UserProfileModel>, IUserProfileView
    {
        public event EventHandler<GetUserByUsernameEventArgs> GettingUser;
        public event EventHandler<RoleEventArgs> AddingRole;
        public event EventHandler<RoleEventArgs> RemovingRole;

        protected void Page_Load(object sender, EventArgs e)
        {
            var username = (string)this.Page.RouteData.Values["username"];

            if (username == null)
            {
                // TODO: redirect to not found
                this.Server.Transfer("~/ErrorPages/404.aspx");
                return;
            }

            if (username == this.User.Identity.GetUserName())
            {
                this.Response.Redirect("~/users/profile");
                return;
            }
            
            this.GettingUser?.Invoke(this, new GetUserByUsernameEventArgs(username, this.Context));
            
            this.DataBind();
        }
    }
}