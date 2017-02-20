using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NUnit.Framework;
using Moq;
using CourseProject.Mvp.CreateAdvertisement;
using CourseProject.Services.Contracts;
using CourseProject.Mvp.ImageResizing;
using CourseProject.Models;
using ImageResizer;
using CourseProject.Mvp.Tests.CreateAdvertisement.CreateAdvertisementPresenterTests.ImageResizerExtensions;

namespace CourseProject.Mvp.Tests.CreateAdvertisement.CreateAdvertisementPresenterTests
{
    [TestFixture]
    public class OnCreatingAdvertisement_Should
    {
        [Test]
        public void CallServiceCreateAdvertisement()
        {
            var model = new CreateAdvertisementModel();
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();
            var mockedFile = new Mock<HttpPostedFileBase>();

            mockedView.Setup(x => x.Model).Returns(model);
            mockedAdsService.Setup(x => x.CreateAdvertisement(It.IsAny<Advertisement>())).Verifiable();
            mockedFactory.Setup(x => x.CreateImageJob(It.IsAny<object>(), It.IsAny<object>(), It.IsAny<Instructions>())).Returns(new Mock<ImageJob>().Object);

            var presenter = new CreateAdvertisementPresenter(
              mockedView.Object,
              mockedAdsService.Object,
              mockedCitiesService.Object,
              mockedCategoriesService.Object,
              mockedFactory.Object,
              mockedSaver.Object);
            var eventArgs = new CreatingAdvertisementEventArgs(
               "name",
               "description",
               10,
               12.34m,
               new DateTime(2017, 2, 20),
               mockedFile.Object,
               1,
               1,
               "seller_id"
               );

            mockedView.Raise(x => x.CreatingAdvertisement += null, eventArgs);

            mockedAdsService.Verify(x => x.CreateAdvertisement(It.IsAny<Advertisement>()), Times.Once);
        }

        [Test]
        public void CallServiceCreateAdvertisementWithCorrectParameters()
        {
            var model = new CreateAdvertisementModel();
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();
            var mockedFile = new Mock<HttpPostedFileBase>();
            Advertisement adToSave = null;
            var filename = "filename.jpg";

            mockedView.Setup(x => x.Model).Returns(model);
            mockedAdsService.Setup(x => x.CreateAdvertisement(It.IsAny<Advertisement>()))
                .Callback<Advertisement>(ad => adToSave = ad);
            mockedFactory.Setup(x => x.CreateImageJob(It.IsAny<object>(), It.IsAny<object>(), It.IsAny<Instructions>())).Returns(new Mock<ImageJob>().Object);
            mockedFile.Setup(x => x.FileName).Returns(filename);

            var presenter = new CreateAdvertisementPresenter(
              mockedView.Object,
              mockedAdsService.Object,
              mockedCitiesService.Object,
              mockedCategoriesService.Object,
              mockedFactory.Object,
              mockedSaver.Object);

            var name = "Name";
            var description = "Description";
            var places = 10;
            var price = 12.34m;
            var date = new DateTime(2017, 2, 20);
            var categoryId = 12;
            var cityId = 18;
            var sellerId = "ofhweofhoiwe123";

            var eventArgs = new CreatingAdvertisementEventArgs(name, description, places, price, date, mockedFile.Object, cityId, categoryId, sellerId);

            mockedView.Raise(x => x.CreatingAdvertisement += null, eventArgs);

            Assert.AreEqual(name, adToSave.Name);
            Assert.AreEqual(description, adToSave.Description);
            Assert.AreEqual(places, adToSave.Places);
            Assert.AreEqual(price, adToSave.Price);
            Assert.AreEqual(date, adToSave.ExpireDate);
            Assert.AreEqual(categoryId, adToSave.CategoryId);
            Assert.AreEqual(cityId, adToSave.CityId);
            Assert.AreEqual(sellerId, adToSave.SellerId);
            Assert.AreEqual("/images/small/" + filename, adToSave.ImagePathSmall);
            Assert.AreEqual("/images/big/" + filename, adToSave.ImagePathBig);
        }

        [Test]
        public void CallFactoryMethodWithCorrectParamsForSmallImage()
        {
            var model = new CreateAdvertisementModel();
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();
            var mockedFile = new Mock<HttpPostedFileBase>();

            var filename = "filename.jpg";
            mockedFile.Setup(x => x.FileName).Returns(filename);

            var smallImagePath = $"~/images/small/{filename}";
            object sourceFromMethod = null;
            Instructions instructionsFromMethod = null;
            mockedView.Setup(x => x.Model).Returns(model);
            mockedFactory.Setup(x => x.CreateImageJob(It.IsAny<object>(), It.IsAny<object>(), It.IsAny<Instructions>())).Returns(new Mock<ImageJob>().Object);
            mockedFactory.Setup(x => x.CreateImageJob(It.IsAny<object>(), smallImagePath, It.IsAny<Instructions>()))
                .Callback<object, object, Instructions>((source, dest, instructions) =>
                {
                    sourceFromMethod = source;
                    instructionsFromMethod = instructions;
                })
                .Returns(new Mock<ImageJob>().Object);

            var presenter = new CreateAdvertisementPresenter(
              mockedView.Object,
              mockedAdsService.Object,
              mockedCitiesService.Object,
              mockedCategoriesService.Object,
              mockedFactory.Object,
              mockedSaver.Object);
            var eventArgs = new CreatingAdvertisementEventArgs("name", "description", 10, 12.34m, new DateTime(2017, 2, 20), mockedFile.Object, 1, 1, "seller_id");

            mockedView.Raise(x => x.CreatingAdvertisement += null, eventArgs);

            Assert.AreEqual(mockedFile.Object, sourceFromMethod);
            Assert.AreEqual(200, instructionsFromMethod.Width);
            Assert.AreEqual(200, instructionsFromMethod.Height);
            Assert.AreEqual(FitMode.Max, instructionsFromMethod.Mode);
            Assert.AreEqual("jpg", instructionsFromMethod.Format);
        }

        [Test]
        public void CallFactoryMethodWithCorrectParamsForLargeImage()
        {
            var model = new CreateAdvertisementModel();
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();
            var mockedFile = new Mock<HttpPostedFileBase>();

            var filename = "filename.jpg";
            mockedFile.Setup(x => x.FileName).Returns(filename);

            var largeImagePath = $"~/images/big/{filename}";
            object sourceFromMethod = null;
            Instructions instructionsFromMethod = null;
            mockedView.Setup(x => x.Model).Returns(model);
            mockedFactory.Setup(x => x.CreateImageJob(It.IsAny<object>(), It.IsAny<object>(), It.IsAny<Instructions>())).Returns(new Mock<ImageJob>().Object);
            mockedFactory.Setup(x => x.CreateImageJob(It.IsAny<object>(), largeImagePath, It.IsAny<Instructions>()))
                .Callback<object, object, Instructions>((source, dest, instructions) =>
                {
                    sourceFromMethod = source;
                    instructionsFromMethod = instructions;
                })
                .Returns(new Mock<ImageJob>().Object);

            var presenter = new CreateAdvertisementPresenter(
              mockedView.Object,
              mockedAdsService.Object,
              mockedCitiesService.Object,
              mockedCategoriesService.Object,
              mockedFactory.Object,
              mockedSaver.Object);
            var eventArgs = new CreatingAdvertisementEventArgs("name", "description", 10, 12.34m, new DateTime(2017, 2, 20), mockedFile.Object, 1, 1, "seller_id");

            mockedView.Raise(x => x.CreatingAdvertisement += null, eventArgs);

            Assert.AreEqual(mockedFile.Object, sourceFromMethod);
            Assert.AreEqual(500, instructionsFromMethod.Width);
            Assert.AreEqual(500, instructionsFromMethod.Height);
            Assert.AreEqual(FitMode.Max, instructionsFromMethod.Mode);
            Assert.AreEqual("jpg", instructionsFromMethod.Format);
        }

        [Test]
        public void CallSaveImageForSmallImage()
        {
            var model = new CreateAdvertisementModel();
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();
            var mockedFile = new Mock<HttpPostedFileBase>();

            var filename = "filename.jpg";
            mockedFile.Setup(x => x.FileName).Returns(filename);
            var smallImagePath = $"~/images/big/{filename}";
            var mockedSmallImage = new Mock<ImageJob>();

            mockedView.Setup(x => x.Model).Returns(model);
            mockedAdsService.Setup(x => x.CreateAdvertisement(It.IsAny<Advertisement>())).Verifiable();
            mockedFactory.Setup(x => x.CreateImageJob(It.IsAny<object>(), It.IsAny<object>(), It.IsAny<Instructions>())).Returns(new Mock<ImageJob>().Object);
            mockedFactory.Setup(x => x.CreateImageJob(It.IsAny<object>(), smallImagePath, It.IsAny<Instructions>()))
                .Returns(mockedSmallImage.Object);
            mockedSaver.Setup(x => x.SaveImage(It.IsAny<ImageJob>(), It.IsAny<bool>())).Verifiable();

            var presenter = new CreateAdvertisementPresenter(
              mockedView.Object,
              mockedAdsService.Object,
              mockedCitiesService.Object,
              mockedCategoriesService.Object,
              mockedFactory.Object,
              mockedSaver.Object);
            var eventArgs = new CreatingAdvertisementEventArgs("name", "description", 10, 12.34m, new DateTime(2017, 2, 20), mockedFile.Object, 1, 1, "seller_id");

            mockedView.Raise(x => x.CreatingAdvertisement += null, eventArgs);

            mockedSaver.Verify(x => x.SaveImage(mockedSmallImage.Object, true), Times.Once);
        }

        [Test]
        public void CallSaveImageForLargeImage()
        {
            var model = new CreateAdvertisementModel();
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();
            var mockedFile = new Mock<HttpPostedFileBase>();

            var filename = "filename.jpg";
            mockedFile.Setup(x => x.FileName).Returns(filename);
            var largeImagePath = $"~/images/big/{filename}";
            var mockedLargeImage = new Mock<ImageJob>();

            mockedView.Setup(x => x.Model).Returns(model);
            mockedAdsService.Setup(x => x.CreateAdvertisement(It.IsAny<Advertisement>())).Verifiable();
            mockedFactory.Setup(x => x.CreateImageJob(It.IsAny<object>(), It.IsAny<object>(), It.IsAny<Instructions>())).Returns(new Mock<ImageJob>().Object);
            mockedFactory.Setup(x => x.CreateImageJob(It.IsAny<object>(), largeImagePath, It.IsAny<Instructions>()))
                .Returns(mockedLargeImage.Object);
            mockedSaver.Setup(x => x.SaveImage(It.IsAny<ImageJob>(), It.IsAny<bool>())).Verifiable();

            var presenter = new CreateAdvertisementPresenter(
              mockedView.Object,
              mockedAdsService.Object,
              mockedCitiesService.Object,
              mockedCategoriesService.Object,
              mockedFactory.Object,
              mockedSaver.Object);
            var eventArgs = new CreatingAdvertisementEventArgs("name", "description", 10, 12.34m, new DateTime(2017, 2, 20), mockedFile.Object, 1, 1, "seller_id");

            mockedView.Raise(x => x.CreatingAdvertisement += null, eventArgs);

            mockedSaver.Verify(x => x.SaveImage(mockedLargeImage.Object, true), Times.Once);
        }
    }
}
