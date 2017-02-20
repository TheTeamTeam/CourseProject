using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CourseProject.Mvp.CreateAdvertisement;
using CourseProject.Services.Contracts;
using CourseProject.Mvp.ImageResizing;
using CourseProject.Models;

namespace CourseProject.Mvp.Tests.CreateAdvertisement.CreateAdvertisementPresenterTests
{
    [TestFixture]
    public class OnInit_Should
    {
        [Test]
        public void CallCitiesServiceGetCitites()
        {
            var model = new CreateAdvertisementModel();
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();

            mockedView.Setup(x => x.Model).Returns(model);
            mockedCitiesService.Setup(x => x.GetCities()).Verifiable();

            var presenter = new CreateAdvertisementPresenter(
              mockedView.Object,
              mockedAdsService.Object,
              mockedCitiesService.Object,
              mockedCategoriesService.Object,
              mockedFactory.Object,
              mockedSaver.Object);

            mockedView.Raise(x => x.MyInit += null, EventArgs.Empty);

            mockedCitiesService.Verify(x => x.GetCities(), Times.Once);
        }

        [Test]
        public void SetModelCitiesWithCorrectCollection()
        {
            var model = new CreateAdvertisementModel();
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();

            var data = new List<City>()
            {
                new Mock<City>().Object,
                new Mock<City>().Object,
                new Mock<City>().Object
            };
            mockedView.Setup(x => x.Model).Returns(model);
            mockedCitiesService.Setup(x => x.GetCities()).Returns(data);

            var presenter = new CreateAdvertisementPresenter(
              mockedView.Object,
              mockedAdsService.Object,
              mockedCitiesService.Object,
              mockedCategoriesService.Object,
              mockedFactory.Object,
              mockedSaver.Object);

            mockedView.Raise(x => x.MyInit += null, EventArgs.Empty);

            CollectionAssert.AreEqual(data, model.Cities);
        }

        [Test]
        public void CallCategoriesServiceGetCategories()
        {
            var model = new CreateAdvertisementModel();
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();

            mockedView.Setup(x => x.Model).Returns(model);
            mockedCategoriesService.Setup(x => x.GetCategories()).Verifiable();

            var presenter = new CreateAdvertisementPresenter(
                mockedView.Object,
                mockedAdsService.Object,
                mockedCitiesService.Object,
                mockedCategoriesService.Object,
                mockedFactory.Object,
                mockedSaver.Object);

            mockedView.Raise(x => x.MyInit += null, EventArgs.Empty);

            mockedCategoriesService.Verify(x => x.GetCategories(), Times.Once);
        }

        [Test]
        public void SetModelCategoriesWithCorrectCollection()
        {
            var model = new CreateAdvertisementModel();
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();

            var data = new List<Category>()
            {
                new Mock<Category>().Object,
                new Mock<Category>().Object,
                new Mock<Category>().Object
            };
            mockedView.Setup(x => x.Model).Returns(model);
            mockedCategoriesService.Setup(x => x.GetCategories()).Returns(data);

            var presenter = new CreateAdvertisementPresenter(
              mockedView.Object,
              mockedAdsService.Object,
              mockedCitiesService.Object,
              mockedCategoriesService.Object,
              mockedFactory.Object,
              mockedSaver.Object);

            mockedView.Raise(x => x.MyInit += null, EventArgs.Empty);

            CollectionAssert.AreEqual(data, model.Categories);
        }
    }
}
