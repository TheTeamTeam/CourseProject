using CourseProject.Models;
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
using Microsoft.AspNet.Identity;
using System.IO;
using ImageResizer;
using System.Globalization;

namespace CourseProject.Web
{
    [PresenterBinding(typeof(CreateAdvertisementPresenter))]
    public partial class CreateAdvertisement : MvpPage<CreateAdvertisementModel>, ICreateAdvertisementView
    {
        public event EventHandler MyInit;
        public event EventHandler<CreatingAdvertisementEventArgs> CreatingAdvertisement;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.MyInit?.Invoke(sender, e);
                
                this.Categories.DataSource = this.Model.Categories;
                this.Categories.DataBind();

                this.Cities.DataSource = this.Model.Cities;
                this.Cities.DataBind();
            }
        }
        protected void CreateAdvertisement_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {           
                var name = this.Name.Text;
                var description = this.Description.Text;
                var places = int.Parse(this.Places.Text);
                var price = decimal.Parse(this.Price.Text);
                var date = DateTime.ParseExact(ExpireDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                var userId = this.Page.User.Identity.GetUserId();
                var categoryId = int.Parse(this.Categories.SelectedValue);
                var cityId = int.Parse(this.Cities.SelectedValue);

                if (Image.HasFile && (Image.PostedFile.ContentType == "image/jpeg" || Image.PostedFile.ContentType == "image/png"))
                {
                    HttpPostedFile file = Image.PostedFile;

                    this.CreatingAdvertisement?.Invoke(sender, new CreatingAdvertisementEventArgs(
                        name,
                        description,
                        places,
                        price,
                        date,
                        file,
                        cityId,
                        categoryId,
                        userId));

                    this.Response.Redirect("~/users/profile");
                }
                else
                {
                    this.ErrorMessage.Text = "Please choose an image file for your ad.";
                }
            }
        }
    }
}