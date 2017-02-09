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
        public event EventHandler<AdDetailsEventArgs> MyInit;
        public event EventHandler<BookAdEventArgs> BookAd;
        public event EventHandler<BookAdEventArgs> SaveAd;

        protected void Page_Load(object sender, EventArgs e)
        {
            string idString = this.Request.QueryString["id"];
            int id = idString != null ? int.Parse(idString) : 1;

            this.MyInit?.Invoke(sender, new AdDetailsEventArgs(id));           

            Page.DataBind();
        }

        protected void BookButton_Click(object sender, EventArgs e)
        {
            var id = this.Page.User.Identity.GetUserId();

            this.BookAd?.Invoke(sender, new BookAdEventArgs(id, Model.Advertisement));
            (sender as Button).Visible = false;
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            var id = this.Page.User.Identity.GetUserId();

            this.SaveAd?.Invoke(sender, new BookAdEventArgs(id, Model.Advertisement));
            (sender as Button).Visible = false;
        }
    }
}