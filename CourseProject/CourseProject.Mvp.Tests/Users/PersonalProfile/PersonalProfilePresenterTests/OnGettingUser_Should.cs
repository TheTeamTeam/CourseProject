using NUnit.Framework;
using Moq;
using CourseProject.Mvp.Tests.Users.PersonalProfile.PersonalProfilePresenterTests.Mocks;
using CourseProject.Services.Contracts;
using CourseProject.Mvp.Users.PersonalProfile;
using CourseProject.Models;

namespace CourseProject.Mvp.Tests.Users.PersonalProfile.PersonalProfilePresenterTests
{
    [TestFixture]
    public class OnGettingUser_Should
    {
        // TODO: Fix tests
        [Test]
        public void CallUserServiceGetUserById()
        {
            var mockedView = new MockedPersonalProfileView();
            var mockedService = new Mock<IUsersService>();
            var mockedAdsService = new Mock<IAdvertisementsService>();

            mockedService.Setup(x => x.GetUserById(It.IsAny<string>())).Verifiable();
            var presenter = new PersonalProfilePresenter(mockedView, mockedService.Object, mockedAdsService.Object);

            mockedView.InvokeGettingUser(mockedView, new Mock<GetUserByIdEventArgs>("id", false).Object);

            mockedService.Verify(x => x.GetUserById(It.IsAny<string>()), Times.Once);
        }
        
        [TestCase("hwoeifho4355")]
        [TestCase("the_id")]
        public void CallGetUserByIdWithCorrectParameter(string id)
        {
            var mockedView = new MockedPersonalProfileView();
            var mockedAdsService = new Mock<IAdvertisementsService>();

            var mockedService = new Mock<IUsersService>();
            mockedService.Setup(x => x.GetUserById(It.IsAny<string>())).Verifiable();
            var presenter = new PersonalProfilePresenter(mockedView, mockedService.Object, mockedAdsService.Object);

            var eventArgs = new GetUserByIdEventArgs(id, false);

            mockedView.InvokeGettingUser(mockedView, eventArgs);

            mockedService.Verify(x => x.GetUserById(id), Times.Once);
        }

        [Test]
        public void SetModelUserCorrectly()
        {
            var mockedView = new MockedPersonalProfileView();
            var mockedAdsService = new Mock<IAdvertisementsService>();

            var mockedService = new Mock<IUsersService>();
            var mockedUser = new Mock<User>();
            mockedService.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(mockedUser.Object);
            var presenter = new PersonalProfilePresenter(mockedView, mockedService.Object, mockedAdsService.Object);
            var eventArgs = new Mock<GetUserByIdEventArgs>("id", false);

            mockedView.InvokeGettingUser(mockedView, eventArgs.Object);

            Assert.AreEqual(mockedUser.Object, mockedView.Model.ProfileUser);
        }
    }
}
