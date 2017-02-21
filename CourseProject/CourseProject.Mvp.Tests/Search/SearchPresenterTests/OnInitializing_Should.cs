using CourseProject.Models;
using CourseProject.Mvp.Search;
using CourseProject.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Mvp.Tests.Search.SearchPresenterTests
{
    [TestFixture]
    public class OnInitializing_Should
    {
        [Test]
        public void CallCitiesServiceGetCitiesMethod()
        {
            var model = new SearchModel();
            var mockedView = new Mock<ISearchView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            mockedView.Setup(x => x.Model).Returns(model);
            var cities = new List<City>()
            {
                new Mock<City>().Object,
                new Mock<City>().Object,
                new Mock<City>().Object
            };
            mockedCitiesService.Setup(x => x.GetCities()).Verifiable();
            mockedCitiesService.Setup(x => x.GetCities()).Returns(cities);
            var searchPresenter = new SearchPresenter(mockedView.Object,
                                                      mockedAdvertisementService.Object,
                                                      mockedCitiesService.Object,
                                                      mockedCategoriesService.Object);
            var eventArgs = new EventArgs();

            mockedView.Raise(x => x.Initializing += null, eventArgs);

            mockedCitiesService.Verify(x => x.GetCities(), Times.Once);
        }

        [Test]
        public void CallCategoriesServiceGetCategoriesMethod()
        {
            var model = new SearchModel();
            var mockedView = new Mock<ISearchView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            mockedView.Setup(x => x.Model).Returns(model);
            var categories = new List<Category>()
            {
                new Mock<Category>().Object,
                new Mock<Category>().Object,
                new Mock<Category>().Object
            };
            mockedCategoriesService.Setup(x => x.GetCategories()).Verifiable();
            mockedCategoriesService.Setup(x => x.GetCategories()).Returns(categories);
            var searchPresenter = new SearchPresenter(mockedView.Object,
                                                      mockedAdvertisementService.Object,
                                                      mockedCitiesService.Object,
                                                      mockedCategoriesService.Object);
            var eventArgs = new EventArgs();

            mockedView.Raise(x => x.Initializing += null, eventArgs);

            mockedCategoriesService.Verify(x => x.GetCategories(), Times.Once);
        }

        [Test]
        public void SetModelCitiesPropertyCorrectly()
        {
            var model = new SearchModel();
            var mockedView = new Mock<ISearchView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            mockedView.Setup(x => x.Model).Returns(model);
            var cities = new List<City>()
            {
                new Mock<City>().Object,
                new Mock<City>().Object,
                new Mock<City>().Object
            };
            mockedCitiesService.Setup(x => x.GetCities()).Returns(cities);
            var searchPresenter = new SearchPresenter(mockedView.Object,
                                                      mockedAdvertisementService.Object,
                                                      mockedCitiesService.Object,
                                                      mockedCategoriesService.Object);
            var eventArgs = new EventArgs();

            mockedView.Raise(x => x.Initializing += null, eventArgs);

            Assert.AreEqual(cities, model.Cities);
        }

        [Test]
        public void SetModelCategoriesPropertyCorrectly()
        {
            var model = new SearchModel();
            var mockedView = new Mock<ISearchView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            mockedView.Setup(x => x.Model).Returns(model);
            var categories = new List<Category>()
            {
                new Mock<Category>().Object,
                new Mock<Category>().Object,
                new Mock<Category>().Object
            };
            mockedCategoriesService.Setup(x => x.GetCategories()).Returns(categories);
            var searchPresenter = new SearchPresenter(mockedView.Object,
                                                      mockedAdvertisementService.Object,
                                                      mockedCitiesService.Object,
                                                      mockedCategoriesService.Object);
            var eventArgs = new EventArgs();

            mockedView.Raise(x => x.Initializing += null, eventArgs);

            Assert.AreEqual(categories, model.Categories);
        }
    }
}
