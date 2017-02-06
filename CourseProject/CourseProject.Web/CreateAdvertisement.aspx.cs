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
        public event EventHandler<CreatingAdvertisementEventArgs> CreatingAdvertisement;

        protected void CreateAdvertisement_Click(object sender, EventArgs e)
        {
            var category = new Category()
            {
                Name = Category.Text
            };

            var city = new City()
            {
                Name = City.Text
            };

            var advertisement = new Advertisement()
            {
                Name = Name.Text,
                Description = Description.Text,
                Places = int.Parse(Places.Text),
                Price = decimal.Parse(Price.Text),
                Category = category,
                City = city
            };

            var id = this.Page.User.Identity.GetUserId();
            advertisement.SellerId = id;

            this.CreatingAdvertisement?.Invoke(sender, new CreatingAdvertisementEventArgs(advertisement));
        }
    }
}