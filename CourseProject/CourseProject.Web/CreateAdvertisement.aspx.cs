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

            var id = this.Page.User.Identity.GetUserId();

            var selectedCategoryId = int.Parse(this.Categories.SelectedValue);
            var category = this.Model.Categories.FirstOrDefault(ca => ca.Id == selectedCategoryId);

            var selectedCityId = int.Parse(this.Cities.SelectedValue);
            var city = this.Model.Cities.FirstOrDefault(c => c.Id == selectedCityId);

            var advertisement = new Advertisement()
            {
                Name = Name.Text,
                Description = Description.Text,
                Places = int.Parse(Places.Text),
                Price = decimal.Parse(Price.Text),
                Category = category,
                CategoryId = category.Id,
                City = city,
                CityId = city.Id,
                SellerId = id
            };
            
            this.CreatingAdvertisement?.Invoke(sender, new CreatingAdvertisementEventArgs(advertisement));
        }
    }
}