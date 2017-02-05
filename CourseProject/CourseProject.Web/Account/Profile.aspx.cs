using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;
using CourseProject.Web.Account.EventArguments;
using CourseProject.Web.Account.Presenters;
using CourseProject.Web.Account.Models;
using CourseProject.Web.Account.Views;


namespace CourseProject.Web.Account
{
    [PresenterBinding(typeof(ProfilePresenter))]
    public partial class Profile : MvpPage<ProfileModel>, IProfileView
    {
        public event EventHandler<GetUserEventArgs> GettingUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = this.Page.User.Identity.GetUserId();
            this.GettingUser?.Invoke(this, new GetUserEventArgs(id));
        }
    }
}