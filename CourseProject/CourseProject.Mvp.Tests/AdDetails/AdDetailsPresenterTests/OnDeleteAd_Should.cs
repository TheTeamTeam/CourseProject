using CourseProject.Mvp.AdDetails;
using CourseProject.Mvp.CommonEventArguments;
using CourseProject.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CourseProject.Mvp.Tests.AdDetails.AdDetailsPresenterTests
{
    [TestFixture]
    public class OnDeleteAd_Should
    {
        [Test]
        public void ShouldCallAdsServiceDeleteAdMethod()
        {
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedAdvertisementService.Setup(x => x.DeleteAd(It.IsAny<int>())).Verifiable();
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);

            var adId = 1;
            var eventArgs = new IdEventArgs(adId);

            mockedView.Raise(x => x.DeleteAd += null, eventArgs);

            mockedAdvertisementService.Verify(x => x.DeleteAd(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void ShouldCallAdsServiceDeleteAdMethodWithCorrectParameter()
        {
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedAdvertisementService.Setup(x => x.DeleteAd(It.IsAny<int>())).Verifiable();
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var adId = 1;
            var eventArgs = new IdEventArgs(adId);

            mockedView.Raise(x => x.DeleteAd += null, eventArgs);

            mockedAdvertisementService.Verify(x => x.DeleteAd(adId), Times.Once);
        }
    }
}
