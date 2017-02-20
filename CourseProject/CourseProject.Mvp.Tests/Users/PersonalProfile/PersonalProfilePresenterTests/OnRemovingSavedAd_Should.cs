using NUnit.Framework;
using Moq;
using CourseProject.Mvp.Users.PersonalProfile;
using CourseProject.Services.Contracts;
using CourseProject.Models;
using CourseProject.Mvp.CommonEventArguments;

namespace CourseProject.Mvp.Tests.Users.PersonalProfile.PersonalProfilePresenterTests
{
    [TestFixture]
    public class OnRemovingSavedAd_Should
    {
        [Test]
        public void CallUserServiceRemoveAdFromSaved()
        {
            var model = new PersonalProfileModel();
            var mockedView = new Mock<IPersonalProfileView>();
            var mockedService = new Mock<IUsersService>();
            var mockedAdsService = new Mock<IAdvertisementsService>();

            mockedView.Setup(x => x.Model).Returns(model);
            mockedService.Setup(x => x.RemoveAdFromSaved(It.IsAny<int>(), It.IsAny<User>())).Verifiable();

            var presenter = new PersonalProfilePresenter(mockedView.Object, mockedService.Object, mockedAdsService.Object);
            var eventArgs = new IdEventArgs(123);

            mockedView.Raise(x => x.RemovingSavedAd += null, eventArgs);

            mockedService.Verify(x => x.RemoveAdFromSaved(It.IsAny<int>(), It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void CallUserServiceRemoveAdFromSavedWithCorrectParameters()
        {
            var model = new PersonalProfileModel();
            var mockedView = new Mock<IPersonalProfileView>();
            var mockedService = new Mock<IUsersService>();
            var mockedAdsService = new Mock<IAdvertisementsService>();

            mockedView.Setup(x => x.Model).Returns(model);
            mockedService.Setup(x => x.RemoveAdFromSaved(It.IsAny<int>(), It.IsAny<User>())).Verifiable();

            var id = 3438;
            var mockedUser = new Mock<User>();
            model.ProfileUser = mockedUser.Object;

            var presenter = new PersonalProfilePresenter(mockedView.Object, mockedService.Object, mockedAdsService.Object);
            var eventArgs = new IdEventArgs(id);

            mockedView.Raise(x => x.RemovingSavedAd += null, eventArgs);

            mockedService.Verify(x => x.RemoveAdFromSaved(id, mockedUser.Object), Times.Once);
        }
    }
}
