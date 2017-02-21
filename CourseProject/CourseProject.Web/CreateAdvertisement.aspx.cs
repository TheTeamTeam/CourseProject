using System;
using System.Globalization;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;
using CourseProject.Mvp.CreateAdvertisement;

namespace CourseProject.Web
{
    [PresenterBinding(typeof(CreateAdvertisementPresenter))]
    public partial class CreateAdvertisement : MvpPage<CreateAdvertisementModel>, ICreateAdvertisementView
    {
        public event EventHandler MyInit;
        public event EventHandler<CreatingAdvertisementEventArgs> CreatingAdvertisement;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
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
                DateTime date;
                if(!DateTime.TryParseExact(ExpireDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.AllowTrailingWhite, out date))
                {
                    this.ErrorMessage.Text = "Date should be in the format month/day/year";
                    return;
                }

                var name = this.Name.Text;
                var description = this.Description.Text;
                var places = int.Parse(this.Places.Text);
                var price = decimal.Parse(this.Price.Text);
                var userId = this.Page.User.Identity.GetUserId();
                var categoryId = int.Parse(this.Categories.SelectedValue);
                var cityId = int.Parse(this.Cities.SelectedValue);

                if (Image.HasFile && (Image.PostedFile.ContentType == "image/jpeg" || Image.PostedFile.ContentType == "image/png"))
                {
                    HttpPostedFileWrapper file = new HttpPostedFileWrapper(Image.PostedFile);

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