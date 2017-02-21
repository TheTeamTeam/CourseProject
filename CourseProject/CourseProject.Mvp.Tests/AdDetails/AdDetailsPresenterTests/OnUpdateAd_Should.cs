using CourseProject.Models;
using CourseProject.Mvp.AdDetails;
using CourseProject.Mvp.CommonEventArguments;
using CourseProject.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace CourseProject.Mvp.Tests.AdDetails.AdDetailsPresenterTests
{
    [TestFixture]
    public class OnUpdateAd_Should
    {
        [Test]
        public void AddModelErrorWhenAdIsNotFound()
        {
            var mockedView = new Mock<IAdDetailsView>();
            mockedView.Setup(x => x.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            var adId = 1;  
            string expectedError = string.Format("Item with id {0} was not found", adId);
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Returns<Advertisement>(null);
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object, 
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);
            var eventArgs = new IdEventArgs(adId);

            mockedView.Raise(x => x.UpdateAd += null, new IdEventArgs(adId));

            Assert.AreEqual(1, mockedView.Object.ModelState[errorKey].Errors.Count);
            StringAssert.AreEqualIgnoringCase(expectedError, mockedView.Object.ModelState[errorKey].Errors[0].ErrorMessage);
        }

        [Test]
        public void TryUpdateModelIsNotCalledWhenAdIsNotFound()
        {
            var mockedView = new Mock<IAdDetailsView>();
            mockedView.Setup(x => x.ModelState).Returns(new ModelStateDictionary());
            string errorKey = string.Empty;
            int adId = 1;
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Returns<Advertisement>(null);
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                            mockedAdvertisementService.Object,
                                                            mockedUsersService.Object);

            mockedView.Raise(x => x.UpdateAd += null, new IdEventArgs(adId));

            mockedView.Verify(v => v.TryUpdateModel(It.IsAny<Advertisement>()), Times.Never());
        }

        [Test]
        public void TryUpdateModelIsCalled_WhenItemIsFound()
        {
            var mockedView = new Mock<IAdDetailsView>();
            mockedView.Setup(x => x.ModelState).Returns(new ModelStateDictionary());
            int adId = 1;
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedAdvertisement = new Mock<Advertisement>();
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Returns(mockedAdvertisement.Object);
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                                       mockedAdvertisementService.Object,
                                                                       mockedUsersService.Object);

            mockedView.Raise(x => x.UpdateAd += null, new IdEventArgs(adId));


            mockedView.Verify(v => v.TryUpdateModel(It.IsAny<Advertisement>()), Times.Once());
        }

        [Test]
        public void UpdateAdIsCalledWhenAdIsFoundAndIsInValidState()
        {
            var mockedView = new Mock<IAdDetailsView>();
            mockedView.Setup(x => x.ModelState).Returns(new ModelStateDictionary());
            int adId = 1;
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedAdvertisement = new Mock<Advertisement>();
            mockedAdvertisementService.Setup(x => x.UpdateAd(It.IsAny<Advertisement>())).Verifiable();
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Returns(mockedAdvertisement.Object);
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                                       mockedAdvertisementService.Object,
                                                                       mockedUsersService.Object);

            mockedView.Raise(x => x.UpdateAd += null, new IdEventArgs(adId));

            mockedAdvertisementService.Verify(x => x.UpdateAd(mockedAdvertisement.Object), Times.Once());
        }

        [Test]
        public void UpdateAdIsNotCalledWhenAdIsFoundAndIsInInvalidState()
        {
            var mockedView = new Mock<IAdDetailsView>();
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("test key", "test message");
            mockedView.Setup(x => x.ModelState).Returns(modelState);
            int adId = 1;
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();
            var mockedAdvertisement = new Mock<Advertisement>();
            mockedAdvertisementService.Setup(x => x.UpdateAd(It.IsAny<Advertisement>())).Verifiable();
            mockedAdvertisementService.Setup(x => x.GetAdById(It.IsAny<int>())).Returns(mockedAdvertisement.Object);
            var adDetailsPresenter = new AdDetailsPresenter(mockedView.Object,
                                                                       mockedAdvertisementService.Object,
                                                                       mockedUsersService.Object);

            mockedView.Raise(x => x.UpdateAd += null, new IdEventArgs(adId));

            mockedAdvertisementService.Verify(x => x.UpdateAd(mockedAdvertisement.Object), Times.Never());
        }
    }
}
