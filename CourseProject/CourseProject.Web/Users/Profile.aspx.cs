using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Presenters;
using CourseProject.Web.Models;
using CourseProject.Web.Views;
using CourseProject.Web.EventArguments.Contracts;

namespace CourseProject.Web.Users
{
    [PresenterBinding(typeof(PersonalProfilePresenter))]
    public partial class Profile : MvpPage<PersonalProfileModel>, IPersonalProfileView
    {
        public event EventHandler<IGetUserByIdEventArgs> GettingUser;
        public event EventHandler<IdEventArgs> RemovingSavedAd;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = this.Page.User.Identity.GetUserId();
            var isSeller = this.Page.User.IsInRole("Seller");
            this.GettingUser?.Invoke(this, new GetUserByIdEventArgs(id, isSeller));
        }

        protected void RemoveFromSaved_Click(object sender, EventArgs e)
        {
            // TODO: Or hidden field or custom control
            var id = int.Parse((sender as Button).Attributes["data-id"]);
            this.RemovingSavedAd?.Invoke(this, new IdEventArgs(id));
        }
    }
}