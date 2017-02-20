using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using CourseProject.Mvp.Home;
using CourseProject.Services.Contracts;
using CourseProject.Models;

namespace CourseProject.Mvp.Tests.Home.HomePresenterTests
{
    [TestFixture]
    public class OnInitializing_Should
    {
        [Test]
        public void CallAdsServiceGetTopAdsWithCorrectParameters()
        {
            var model = new HomeModel();
            var mockedView = new Mock<IHomeView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();

            mockedView.Setup(x => x.Model).Returns(model);
            mockedAdsService.Setup(x => x.GetTopAds(It.IsAny<int>())).Verifiable();

            int count = 19;
            var presenter = new HomePresenter(mockedView.Object, mockedAdsService.Object);
            var eventArgs = new CountEventArgs(count);

            mockedView.Raise(x => x.Initializing += null, eventArgs);

            mockedAdsService.Verify(x => x.GetTopAds(count), Times.Once);
        }

        [Test]
        public void SetModelTopAdsPropertyCorrectly()
        {
            var model = new HomeModel();
            var mockedView = new Mock<IHomeView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            mockedView.Setup(x => x.Model).Returns(model);

            var topAds = new List<Advertisement>()
            {
                new Mock<Advertisement>().Object,
                new Mock<Advertisement>().Object,
                new Mock<Advertisement>().Object
            };
            mockedAdsService.Setup(x => x.GetTopAds(It.IsAny<int>())).Returns(topAds);

            int count = 19;
            var presenter = new HomePresenter(mockedView.Object, mockedAdsService.Object);
            var eventArgs = new CountEventArgs(count);

            mockedView.Raise(x => x.Initializing += null, eventArgs);

            CollectionAssert.AreEqual(topAds, model.TopAds);
        }
    }
}
