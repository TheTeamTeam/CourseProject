using System;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;
using CourseProject.Mvp.Users.UserProfile;

namespace CourseProject.Web.Users
{
    [PresenterBinding(typeof(UserProfilePresenter))]
    public partial class UserProfile : MvpPage<UserProfileModel>, IUserProfileView
    {
        public event EventHandler<GetUserByUsernameEventArgs> GettingUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            var username = (string)this.Page.RouteData.Values["username"];

            if (username == null)
            {
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