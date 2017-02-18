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
using System.Web.ModelBinding;

namespace CourseProject.Web
{
    [PresenterBinding(typeof(AdDetailsPresenter))]
    public partial class AdDetails : MvpPage<AdDetailsModel>, IAdDetailsView
    {
        public event EventHandler<AdDetailsEventArgs> Initializing;
        public event EventHandler<BookAdEventArgs> BookAd;
        public event EventHandler<SaveAdEventArgs> SaveAd;
        public event EventHandler<IdEventArgs> DeleteAd;
        public event EventHandler<IdEventArgs> UpdateAd;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BookButton_Click(object sender, EventArgs e)
        {
            string id = this.Page.User.Identity.GetUserId();

            this.BookAd?.Invoke(sender, new BookAdEventArgs(id, this.Model.Advertisement));     
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            var id = this.Page.User.Identity.GetUserId();

            this.SaveAd?.Invoke(sender, new SaveAdEventArgs(id, this.Model.Advertisement));
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        // TODO: Decide where to leave logic
        public Advertisement AdForm_GetItem([QueryString] int? id)
        {
            int adId = id ?? 1;
            string userId = this.Page.User.Identity.GetUserId();

            this.Initializing?.Invoke(this, new AdDetailsEventArgs(adId, userId));

            if (this.Model.Advertisement == null)
            {
                this.Response.Redirect("~/errorPages/404");
            }

            return this.Model.Advertisement;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AdForm_DeleteItem(int id)
        {
            this.DeleteAd?.Invoke(this, new IdEventArgs(id));
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AdForm_UpdateItem(int id)
        {
            this.UpdateAd?.Invoke(this, new IdEventArgs(id));
        }
    }
}