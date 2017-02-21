using System;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;
using CourseProject.Models;
using CourseProject.Mvp.AdDetails;
using CourseProject.Mvp.CommonEventArguments;

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
            var adStringId = this.Request.QueryString["id"];
            int adId = adStringId != null ? int.Parse(adStringId) : 1;
            string userId = this.Page.User.Identity.GetUserId();

            this.Initializing?.Invoke(this, new AdDetailsEventArgs(adId, userId));

            if (this.Model.Advertisement == null)
            {
                this.Response.Redirect("~/errorPages/404");
            }
        }
        
        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        // TODO: Decide where to leave logic
        public Advertisement AdForm_GetItem([QueryString] int? id)
        {         
            // If initializing event is called here, on button click, the model.advertisement is null.
            return this.Model.Advertisement;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AdForm_DeleteItem(int id)
        {
            this.DeleteAd?.Invoke(this, new IdEventArgs(id));
            this.Response.Redirect("~/");
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AdForm_UpdateItem(int id)
        {
            this.UpdateAd?.Invoke(this, new IdEventArgs(id));
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
    }
}