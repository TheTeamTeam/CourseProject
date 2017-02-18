using WebFormsMvp;
using CourseProject.Data.Repositories;
using CourseProject.Models;
using CourseProject.Services.Contracts;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Views;
using System;
using System.IO;
using ImageResizer;
using System.Web;

namespace CourseProject.Web.Presenters
{
    public class CreateAdvertisementPresenter : Presenter<ICreateAdvertisementView>
    {
        private IAdvertisementsService adsService;
        private readonly ICitiesService citiesService;
        private readonly ICategoriesService categoriesService;

        public CreateAdvertisementPresenter(
            ICreateAdvertisementView view,
            IAdvertisementsService adsService,
            ICitiesService citiesService,
            ICategoriesService categoriesService)
            : base(view)
        {
            if (adsService == null)
            {
                throw new ArgumentNullException("Ads service cannot be null.");
            }

            if (citiesService == null)
            {
                throw new ArgumentNullException("Cities service cannot be null.");
            }

            if (categoriesService == null)
            {
                throw new ArgumentNullException("Categories service cannot be null.");
            }

            this.adsService = adsService;
            this.citiesService = citiesService;
            this.categoriesService = categoriesService;

            this.View.MyInit += OnInit;
            this.View.CreatingAdvertisement += OnCreatingAdvertisement;
        }

        private void OnInit(object sender, EventArgs e)
        {
            this.View.Model.Categories = this.categoriesService.GetCategories();
            this.View.Model.Cities = this.citiesService.GetCities();
        }

        private void OnCreatingAdvertisement(object sender, CreatingAdvertisementEventArgs e)
        {
            var filename = Path.GetFileName(e.Image.FileName);
            this.SaveImagesToFileSystem(e.Image, filename);

            var advertisement = new Advertisement()
            {
                Name = e.Name,
                Description = e.Description,
                Places = e.Places,
                Price = e.Price,
                ExpireDate = e.ExpireDate,
                CityId = e.CityId,
                CategoryId = e.CategoryId,
                SellerId = e.SellerId,
                // TODO: have default image
                ImagePathSmall = filename != null ? "/images/small/" + filename : null,
                ImagePathBig = filename != null ? "/images/big/" + filename : null,
            };

            this.adsService.CreateAdvertisement(advertisement);
        }

        private void SaveImagesToFileSystem(HttpPostedFile image, string filename)
        {
            //The resizing settings can specify any of 30 commands.. See http://imageresizing.net for details.
            //Destination paths can have variables like <guid> and <ext>, or 
            //even a santizied version of the original filename, like <filename:A-Za-z0-9>
            ImageJob i = new ImageJob(image,
                $"~/images/small/{filename}",
                new Instructions("width=200;height=200;format=jpg;mode=max"));
            i.CreateParentDirectory = true; //Auto-create the uploads directory.
            i.Build();

            ImageJob j = new ImageJob(image,
                $"~/images/big/{filename}",
                new Instructions("width=500;height=500;format=jpg;mode=max"));
            j.CreateParentDirectory = true; //Auto-create the uploads directory.
            j.Build();

        }
    }
}