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
    public class OnSearching_Should
    {
        [Test]
        public void CallAdsServiceSearchAdsMethod()
        {
            var model = new SearchModel();
            var mockedView = new Mock<ISearchView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            mockedView.Setup(x => x.Model).Returns(model);
            var advertisements = new List<Advertisement>()
            {
                new Mock<Advertisement>().Object,
                new Mock<Advertisement>().Object,
                new Mock<Advertisement>().Object
            }.AsQueryable();

            mockedAdvertisementService.Setup(x => x.SearchAds(It.IsAny<string>(),
                                                              It.IsAny<string>(),
                                                              It.IsAny<int>(),
                                                              It.IsAny<int>())).Verifiable();
            mockedAdvertisementService.Setup(x => x.SearchAds(It.IsAny<string>(),
                                                              It.IsAny<string>(),
                                                              It.IsAny<int>(),
                                                              It.IsAny<int>())).Returns(advertisements);
            var searchPresenter = new SearchPresenter(mockedView.Object,
                                                      mockedAdvertisementService.Object,
                                                      mockedCitiesService.Object,
                                                      mockedCategoriesService.Object);
            string searchWord = "search";
            string orderBy = "orderBy";
            int categoryId = 1;
            int cityId = 1;
            var eventArgs = new SearchEventArgs(searchWord, orderBy, categoryId, cityId);

            mockedView.Raise(x => x.Searching += null, eventArgs);

            mockedAdvertisementService.Verify(x => x.SearchAds(It.IsAny<string>(),
                                                               It.IsAny<string>(),
                                                               It.IsAny<int>(),
                                                               It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void CallAdsServiceSearchAdsMethodWithCorrectParameters()
        {
            var model = new SearchModel();
            var mockedView = new Mock<ISearchView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            mockedView.Setup(x => x.Model).Returns(model);
            var advertisements = new List<Advertisement>()
            {
                new Mock<Advertisement>().Object,
                new Mock<Advertisement>().Object,
                new Mock<Advertisement>().Object
            }.AsQueryable();

            mockedAdvertisementService.Setup(x => x.SearchAds(It.IsAny<string>(),
                                                              It.IsAny<string>(),
                                                              It.IsAny<int>(),
                                                              It.IsAny<int>())).Verifiable();
            mockedAdvertisementService.Setup(x => x.SearchAds(It.IsAny<string>(),
                                                              It.IsAny<string>(),
                                                              It.IsAny<int>(),
                                                              It.IsAny<int>())).Returns(advertisements);
            var searchPresenter = new SearchPresenter(mockedView.Object,
                                                      mockedAdvertisementService.Object,
                                                      mockedCitiesService.Object,
                                                      mockedCategoriesService.Object);
            string searchWord = "search";
            string orderBy = "orderBy";
            int categoryId = 1;
            int cityId = 1;
            var eventArgs = new SearchEventArgs(searchWord, orderBy, categoryId, cityId);

            mockedView.Raise(x => x.Searching += null, eventArgs);

            mockedAdvertisementService.Verify(x => x.SearchAds(searchWord,
                                                               orderBy,
                                                               categoryId,
                                                               cityId), Times.Once);
        }

        [Test]
        public void SetModelAdvertisementsCorrectly()
        {
            var model = new SearchModel();
            var mockedView = new Mock<ISearchView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            mockedView.Setup(x => x.Model).Returns(model);
            var advertisements = new List<Advertisement>()
            {
                new Mock<Advertisement>().Object,
                new Mock<Advertisement>().Object,
                new Mock<Advertisement>().Object
            }.AsQueryable();

            mockedAdvertisementService.Setup(x => x.SearchAds(It.IsAny<string>(),
                                                              It.IsAny<string>(),
                                                              It.IsAny<int>(),
                                                              It.IsAny<int>())).Verifiable();
            mockedAdvertisementService.Setup(x => x.SearchAds(It.IsAny<string>(),
                                                              It.IsAny<string>(),
                                                              It.IsAny<int>(),
                                                              It.IsAny<int>())).Returns(advertisements);
            var searchPresenter = new SearchPresenter(mockedView.Object,
                                                      mockedAdvertisementService.Object,
                                                      mockedCitiesService.Object,
                                                      mockedCategoriesService.Object);
            string searchWord = "search";
            string orderBy = "orderBy";
            int categoryId = 1;
            int cityId = 1;
            var eventArgs = new SearchEventArgs(searchWord, orderBy, categoryId, cityId);

            mockedView.Raise(x => x.Searching += null, eventArgs);

            Assert.AreEqual(advertisements, model.Advertisements);
        }
    }
}
