using CourseProject.Models;
using CourseProject.Mvp.AdDetails;
using CourseProject.Services;
using CourseProject.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Mvp.Tests.AdDetails.AdDetailsPresenterTests
{
    [TestFixture]
    public class OnInitializing_Should
    {
        [Test]
        public void CallAdsServiceGetAdById()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Verifiable();
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Returns(mockedAd.Object);          
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var eventArgs = new AdDetailsEventArgs(1, null);

            mockedView.Raise(x => x.Initializing += null, eventArgs);

            mockedAdvertisementService.Verify(x => x.GetAdById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void CallAdsServiceGetAdByIdWithCorrectParameters()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Verifiable();
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Returns(mockedAd.Object);
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            int adId = 1;
            var eventArgs = new AdDetailsEventArgs(adId, null);

            mockedView.Raise(x => x.Initializing += null, eventArgs);

            mockedAdvertisementService.Verify(x => x.GetAdById(adId), Times.Once);
        }

        [Test]
        public void ShouldSetModelAdvertisementPropertyCorrectly()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Returns(mockedAd.Object);
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var eventArgs = new AdDetailsEventArgs(1, null);

            mockedView.Raise(x => x.Initializing += null, eventArgs);

            Assert.AreEqual(mockedAd.Object, model.Advertisement);
        }

        [Test]
        public void ShouldSetModelBookButtonVisiblePropertyToFalseIfUserIdIsNull()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Returns(mockedAd.Object);
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var eventArgs = new AdDetailsEventArgs(1, null);

            mockedView.Raise(x => x.Initializing += null, eventArgs);

            Assert.AreEqual(false, model.BookButtonVisible);
        }

        [Test]
        public void ShouldSetModelBookButtonVisiblePropertyToFalseIfUserIdIsNotNullAndUserBookedAdIsTrue()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Returns(mockedAd.Object);
            mockedUsersService.Setup(x => x.UserBookedAd(It.IsAny<string>(), It.IsAny<Advertisement>())).Returns(true);            
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var eventArgs = new AdDetailsEventArgs(1, "1a");

            mockedView.Raise(x => x.Initializing += null, eventArgs);

            Assert.AreEqual(false, model.BookButtonVisible);
        }

        [Test]
        public void ShouldSetModelBookButtonVisiblePropertyToTrueIfUserIdIsNotNullAndUserBookedAdIsFalse()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Returns(mockedAd.Object);
            mockedUsersService.Setup(x => x.UserBookedAd(It.IsAny<string>(), It.IsAny<Advertisement>())).Returns(false);
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var eventArgs = new AdDetailsEventArgs(1, "1a");

            mockedView.Raise(x => x.Initializing += null, eventArgs);

            Assert.AreEqual(true, model.BookButtonVisible);
        }

        [Test]
        public void ShouldSetModelSaveButtonVisiblePropertyToFalseIfUserIdIsNull()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Returns(mockedAd.Object);
            var mockedUsersService = new Mock<IUsersService>();
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var eventArgs = new AdDetailsEventArgs(1, null);

            mockedView.Raise(x => x.Initializing += null, eventArgs);

            Assert.AreEqual(false, model.SaveButtonVisible);
        }

        [Test]
        public void ShouldSetModelSaveButtonVisiblePropertyToFalseIfUserIdIsNotNullAndUserSavedAdIsTrue()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Returns(mockedAd.Object);
            mockedUsersService.Setup(x => x.UserSavedAd(It.IsAny<string>(), It.IsAny<Advertisement>())).Returns(true);
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var eventArgs = new AdDetailsEventArgs(1, "1a");

            mockedView.Raise(x => x.Initializing += null, eventArgs);

            Assert.AreEqual(false, model.SaveButtonVisible);
        }

        [Test]
        public void ShouldSetModelSaveButtonVisiblePropertyToTrueIfUserIdIsNotNullAndUserSavedAdIsFalse()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Returns(mockedAd.Object);
            mockedUsersService.Setup(x => x.UserSavedAd(It.IsAny<string>(), It.IsAny<Advertisement>())).Returns(false);
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var eventArgs = new AdDetailsEventArgs(1, "1a");

            mockedView.Raise(x => x.Initializing += null, eventArgs);

            Assert.AreEqual(true, model.SaveButtonVisible);
        }
    }
}
