using System;
using System.IO;
using System.Web;
using ImageResizer;
using WebFormsMvp;
using CourseProject.Models;
using CourseProject.Services.Contracts;
using CourseProject.Mvp.ImageResizing;

namespace CourseProject.Mvp.CreateAdvertisement
{
    public class CreateAdvertisementPresenter : Presenter<ICreateAdvertisementView>
    {
        private readonly IAdvertisementsService adsService;
        private readonly ICitiesService citiesService;
        private readonly ICategoriesService categoriesService;
        private readonly IImageJobFactory imageJobFactory;
        private readonly IImageSaver imageSaver;

        public CreateAdvertisementPresenter(
            ICreateAdvertisementView view,
            IAdvertisementsService adsService,
            ICitiesService citiesService,
            ICategoriesService categoriesService,
            IImageJobFactory imageJobFactory,
            IImageSaver imageSaver)
            : base(view)
        {
            if (adsService == null)
            {
                throw new ArgumentNullException("Advertisements service cannot be null.");
            }

            if (citiesService == null)
            {
                throw new ArgumentNullException("Cities service cannot be null.");
            }

            if (categoriesService == null)
            {
                throw new ArgumentNullException("Categories service cannot be null.");
            }

            if (imageJobFactory == null)
            {
                throw new ArgumentNullException("Image job factory cannot be null.");
            }

            if (imageSaver == null)
            {
                throw new ArgumentNullException("Image saver cannot be null.");
            }

            this.adsService = adsService;
            this.citiesService = citiesService;
            this.categoriesService = categoriesService;
            this.imageJobFactory = imageJobFactory;
            this.imageSaver = imageSaver;

            this.View.MyInit += this.OnInit;
            this.View.CreatingAdvertisement += this.OnCreatingAdvertisement;
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

        private void SaveImagesToFileSystem(HttpPostedFileBase image, string filename)
        {
            // The resizing settings can specify any of 30 commands.. See http://imageresizing.net for details.
            // Destination paths can have variables like <guid> and <ext>, or 
            // even a santizied version of the original filename, like <filename:A-Za-z0-9>
            ImageJob smallImage =this.imageJobFactory.CreateImageJob(
                image,
                $"~/images/small/{filename}",
                new Instructions("width=200;height=200;format=jpg;mode=max"));
            this.imageSaver.SaveImage(smallImage, true);
            
            ImageJob largeImage = this.imageJobFactory.CreateImageJob(
                image,
                $"~/images/big/{filename}",
                new Instructions("width=500;height=500;format=jpg;mode=max"));
            this.imageSaver.SaveImage(largeImage, true);
        }
    }
}