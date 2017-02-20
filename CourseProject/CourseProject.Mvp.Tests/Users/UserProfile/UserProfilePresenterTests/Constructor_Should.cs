using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CourseProject.Mvp.Users.UserProfile;
using CourseProject.Services.Contracts;

namespace CourseProject.Mvp.Tests.Users.UserProfile.UserProfilePresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUsersServiceIsNull()
        {
            var mockedView = new Mock<IUserProfileView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();

            Assert.Throws<ArgumentNullException>(() => new UserProfilePresenter(
                mockedView.Object,
                null,
                mockedAdsService.Object));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenUsersServiceIsNull()
        {
            var mockedView = new Mock<IUserProfileView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();

            Assert.That(() => new UserProfilePresenter(mockedView.Object, null, mockedAdsService.Object),
                    Throws.ArgumentNullException.With.Message.Contains("Users service cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenAdvertisementsServiceIsNull()
        {
            var mockedView = new Mock<IUserProfileView>();
            var mockedUsersService = new Mock<IUsersService>();

            Assert.Throws<ArgumentNullException>(() => new UserProfilePresenter(
                mockedView.Object,
                mockedUsersService.Object,
                null));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenAdvertisementsServiceIsNull()
        {
            var mockedView = new Mock<IUserProfileView>();
            var mockedUsersService = new Mock<IUsersService>();

            Assert.That(() => new UserProfilePresenter(mockedView.Object, mockedUsersService.Object, null),
                    Throws.ArgumentNullException.With.Message.Contains("Advertisements service cannot be null."));
        }
    }
}
