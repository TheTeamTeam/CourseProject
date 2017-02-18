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
            this.MyInit?.Invoke(sender, e);

            if (!IsPostBack)
            {             
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

                var id = this.Page.User.Identity.GetUserId();

                var selectedCategoryId = int.Parse(this.Categories.SelectedValue);
                var category = this.Model.Categories.FirstOrDefault(ca => ca.Id == selectedCategoryId);

                var selectedCityId = int.Parse(this.Cities.SelectedValue);
                var city = this.Model.Cities.FirstOrDefault(c => c.Id == selectedCityId);

                string filename = null;

                if (Image.HasFile)
                {
                    if (Image.PostedFile.ContentType == "image/jpeg" || Image.PostedFile.ContentType == "image/png")
                    {
                        HttpPostedFile file = Image.PostedFile;
                        filename = Path.GetFileName(Image.FileName);

                        //The resizing settings can specify any of 30 commands.. See http://imageresizing.net for details.
                        //Destination paths can have variables like <guid> and <ext>, or 
                        //even a santizied version of the original filename, like <filename:A-Za-z0-9>
                        ImageJob i = new ImageJob(file, $"~/images/small/{filename}", 
                            new Instructions("width=200;height=200;format=jpg;mode=max"));
                        i.CreateParentDirectory = true; //Auto-create the uploads directory.
                        i.Build();

                        ImageJob j = new ImageJob(file, $"~/images/big/{filename}",
                            new Instructions("width=500;height=500;format=jpg;mode=max"));
                        j.CreateParentDirectory = true; //Auto-create the uploads directory.
                        j.Build();
                    }
                    else
                    {
                        //TODO: File format shoud be png or jpeg
                    }
                }

                var date = DateTime.ParseExact(ExpireDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                var advertisement = new Advertisement()
                {
                    Name = Name.Text,
                    Description = Description.Text,
                    Places = int.Parse(Places.Text),
                    Price = decimal.Parse(Price.Text),
                    ExpireDate = date,
                    ImagePathSmall = filename != null ? "/images/small/" + filename : null,
                    ImagePathBig = filename != null ? "/images/big/" + filename : null,
                    Category = category,
                    CategoryId = category.Id,
                    City = city,
                    CityId = city.Id,
                    SellerId = id
                };

                this.CreatingAdvertisement?.Invoke(sender, new CreatingAdvertisementEventArgs(advertisement));

                this.Response.Redirect("~/users/profile");
            }
        }
    }
}