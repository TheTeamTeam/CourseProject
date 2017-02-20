using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CourseProject.Mvp.Tests.Users.PersonalProfile.PersonalProfilePresenterTests.Mocks;
using CourseProject.Services.Contracts;
using CourseProject.Mvp.Users.PersonalProfile;

namespace CourseProject.Mvp.Tests.Users.PersonalProfile.PersonalProfilePresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUserServiceIsNull()
        {
            var mockedView = new Mock<IPersonalProfileView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();

            Assert.Throws<ArgumentNullException>(() => new PersonalProfilePresenter(mockedView.Object, null, mockedAdsService.Object));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenUserServiceIsNull()
        {
            var mockedView = new Mock<IPersonalProfileView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();

            Assert.That(() => new PersonalProfilePresenter(mockedView.Object, null, mockedAdsService.Object),
                    Throws.ArgumentNullException.With.Message.Contains("Users service cannot be null."));
        }

        //[Test]
        //public void AttachEventToViewGettingUser()
        //{
        //    var mockedView = new MockedPersonalProfileView();
        //    var mockedService = new Mock<IUsersService>();
        //    var mockedAdsService = new Mock<IAdvertisementsService>();

        //    var presenter = new PersonalProfilePresenter(mockedView, mockedService.Object, mockedAdsService.Object);

        //    Assert.IsTrue(mockedView.IsSubscribedGettingUser("OnGettingUser"));
        //}
    }
}
