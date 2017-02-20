using CourseProject.Models;
using CourseProject.Mvp.AdDetails;
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
    public class OnBookAd_Should
    {
        [Test]
        public void ShouldNotCallUsersServiceAddAdToUpcomingMethodWhenUserBookedAdReturnTrue()
        {
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(x => x.UserBookedAd(It.IsAny<string>(), It.IsAny<Advertisement>())).Returns(true);
            mockedUsersService.Setup(x => x.AddAdToUpcoming(It.IsAny<string>(), It.IsAny<Advertisement>())).Verifiable();
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var userId = "1a";
            var eventArgs = new BookAdEventArgs(userId, mockedAd.Object);

            mockedView.Raise(x => x.BookAd += null, eventArgs);

            mockedUsersService.Verify(x => x.AddAdToUpcoming(It.IsAny<string>(), It.IsAny<Advertisement>()), Times.Never);
        }

        [Test]
        public void ShouldNotCallAdsServiceDecrementFreePlacesMethodWhenUserBookedAdReturnTrue()
        {
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(x => x.UserBookedAd(It.IsAny<string>(), It.IsAny<Advertisement>())).Returns(true);
            mockedAdvertisementService.Setup(x => x.DecrementFreePlaces(It.IsAny<Advertisement>())).Verifiable();
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var userId = "1a";
            var eventArgs = new BookAdEventArgs(userId, mockedAd.Object);

            mockedView.Raise(x => x.BookAd += null, eventArgs);

            mockedAdvertisementService.Verify(x => x.DecrementFreePlaces(It.IsAny<Advertisement>()), Times.Never);
        }

        [Test]
        public void ShouldCallUsersServiceAddAdToUpcomingMethodWhenUserBookedAdReturnFalse()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedUsersService.Setup(x => x.UserBookedAd(It.IsAny<string>(), It.IsAny<Advertisement>())).Returns(false);
            mockedUsersService.Setup(x => x.AddAdToUpcoming(It.IsAny<string>(), It.IsAny<Advertisement>())).Verifiable();
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var userId = "1a";
            var eventArgs = new BookAdEventArgs(userId, mockedAd.Object);

            mockedView.Raise(x => x.BookAd += null, eventArgs);

            mockedUsersService.Verify(x => x.AddAdToUpcoming(It.IsAny<string>(), It.IsAny<Advertisement>()), Times.Once);
        }

        [Test]
        public void ShouldCallUsersServiceAddAdToUpcomingMethodWithCorrectParametersWhenUserBookedAdReturnFalse()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedUsersService.Setup(x => x.UserBookedAd(It.IsAny<string>(), It.IsAny<Advertisement>())).Returns(false);
            mockedUsersService.Setup(x => x.AddAdToUpcoming(It.IsAny<string>(), It.IsAny<Advertisement>())).Verifiable();
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var userId = "1a";
            var eventArgs = new BookAdEventArgs(userId, mockedAd.Object);

            mockedView.Raise(x => x.BookAd += null, eventArgs);

            mockedUsersService.Verify(x => x.AddAdToUpcoming(userId, mockedAd.Object), Times.Once);
        }

        [Test]
        public void ShouldCallAdsServiceDecrementFreePlacesMethodWhenUserBookedAdReturnFalse()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedUsersService.Setup(x => x.UserBookedAd(It.IsAny<string>(), It.IsAny<Advertisement>())).Returns(false);
            mockedAdvertisementService.Setup(x => x.DecrementFreePlaces(It.IsAny<Advertisement>())).Verifiable();
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var userId = "1a";
            var eventArgs = new BookAdEventArgs(userId, mockedAd.Object);

            mockedView.Raise(x => x.BookAd += null, eventArgs);

            mockedAdvertisementService.Verify(x => x.DecrementFreePlaces(It.IsAny<Advertisement>()), Times.Once);
        }

        [Test]
        public void ShouldCallAdsServiceDecrementFreePlacesWithCorrectParametersWhenUserBookedAdReturnFalse()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedUsersService.Setup(x => x.UserBookedAd(It.IsAny<string>(), It.IsAny<Advertisement>())).Returns(false);
            mockedAdvertisementService.Setup(x => x.DecrementFreePlaces(It.IsAny<Advertisement>())).Verifiable();
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var userId = "1a";
            var eventArgs = new BookAdEventArgs(userId, mockedAd.Object);

            mockedView.Raise(x => x.BookAd += null, eventArgs);

            mockedAdvertisementService.Verify(x => x.DecrementFreePlaces(mockedAd.Object), Times.Once);
        }

        [Test]
        public void ShouldSetBookButtonVisibleToFalseWhenUserBookedAdReturnFalse()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedUsersService.Setup(x => x.UserBookedAd(It.IsAny<string>(), It.IsAny<Advertisement>())).Returns(false);          
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var userId = "1a";
            var eventArgs = new BookAdEventArgs(userId, mockedAd.Object);

            mockedView.Raise(x => x.BookAd += null, eventArgs);

            Assert.AreEqual(false, model.BookButtonVisible);
        }
    }
}
