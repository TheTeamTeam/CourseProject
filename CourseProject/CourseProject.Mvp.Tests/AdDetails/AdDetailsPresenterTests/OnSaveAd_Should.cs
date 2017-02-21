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
    public class OnSaveAd_Should
    {
        [Test]
        public void ShouldNotCallUsersServiceAddAdToSavedMethodWhenUserSavedAdReturnsTrue()
        {
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedUsersService.Setup(x => x.UserSavedAd(It.IsAny<string>(), It.IsAny<Advertisement>())).Returns(true);
            mockedUsersService.Setup(x => x.AddAdToSaved(It.IsAny<string>(), It.IsAny<Advertisement>())).Verifiable();
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var userId = "1a";
            var eventArgs = new SaveAdEventArgs(userId, mockedAd.Object);

            mockedView.Raise(x => x.SaveAd += null, eventArgs);

            mockedUsersService.Verify(x => x.AddAdToSaved(It.IsAny<string>(), It.IsAny<Advertisement>()), Times.Never);
        }

        [Test]
        public void ShouldCallUsersServiceAddAdToSavedMethodWhenUserSavedAdReturnsFalse()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedUsersService.Setup(x => x.UserSavedAd(It.IsAny<string>(), It.IsAny<Advertisement>())).Returns(false);
            mockedUsersService.Setup(x => x.AddAdToSaved(It.IsAny<string>(), It.IsAny<Advertisement>())).Verifiable();
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var userId = "1a";
            var eventArgs = new SaveAdEventArgs(userId, mockedAd.Object);

            mockedView.Raise(x => x.SaveAd += null, eventArgs);

            mockedUsersService.Verify(x => x.AddAdToSaved(It.IsAny<string>(), It.IsAny<Advertisement>()), Times.Once);
        }

        [Test]
        public void ShouldCallUsersServiceAddAdToSavedMethodWithCorrectParametersWhenUserSavedAdReturnsFalse()
        {
            var model = new AdDetailsModel();
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedUsersService.Setup(x => x.UserSavedAd(It.IsAny<string>(), It.IsAny<Advertisement>())).Returns(false);
            mockedUsersService.Setup(x => x.AddAdToSaved(It.IsAny<string>(), It.IsAny<Advertisement>())).Verifiable();
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var userId = "1a";
            var eventArgs = new SaveAdEventArgs(userId, mockedAd.Object);

            mockedView.Raise(x => x.SaveAd += null, eventArgs);

            mockedUsersService.Verify(x => x.AddAdToSaved(userId, mockedAd.Object), Times.Once);
        }

        [Test]
        public void ShouldSetSaveButtonVisibleToFalseWhenUserSavedAdReturnsFalse()
        {
            var model = new AdDetailsModel();
            model.SaveButtonVisible = true;
            var mockedAd = new Mock<Advertisement>();
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedView.Setup(x => x.Model).Returns(model);
            mockedUsersService.Setup(x => x.UserSavedAd(It.IsAny<string>(), It.IsAny<Advertisement>())).Returns(false);
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var userId = "1a";
            var eventArgs = new SaveAdEventArgs(userId, mockedAd.Object);

            mockedView.Raise(x => x.SaveAd += null, eventArgs);

            Assert.AreEqual(false, model.SaveButtonVisible);
        }
    }
}
