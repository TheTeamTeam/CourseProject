using CourseProject.Web.Models;
using CourseProject.Web.Presenters;
using CourseProject.Web.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using CourseProject.Web.EventArguments;
using CourseProject.Models;
using Microsoft.AspNet.Identity;

namespace CourseProject.Web
{
    [PresenterBinding(typeof(AdDetailsPresenter))]
    public partial class AdDetails : MvpPage<AdDetailsModel>, IAdDetailsView
    {
        public event EventHandler<AdDetailsEventArgs> Initializing;
        public event EventHandler<BookAdEventArgs> BookAd;
        public event EventHandler<SaveAdEventArgs> SaveAd;

        protected void Page_Load(object sender, EventArgs e)
        {
            string adIdString = this.Request.QueryString["id"];
            int adId = adIdString != null ? int.Parse(adIdString) : 1;
            string userId = this.Page.User.Identity.GetUserId();

            this.Initializing?.Invoke(sender, new AdDetailsEventArgs(adId, userId));           
            if (this.Model.Advertisement == null)
            {
                this.Response.Redirect("~/errorPages/404");
            }
            Page.DataBind();
        }

        protected void BookButton_Click(object sender, EventArgs e)
        {
            string id = this.Page.User.Identity.GetUserId();

            this.BookAd?.Invoke(sender, new BookAdEventArgs(id, Model.Advertisement));     
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            var id = this.Page.User.Identity.GetUserId();

            this.SaveAd?.Invoke(sender, new SaveAdEventArgs(id, Model.Advertisement));
        }
    }
}