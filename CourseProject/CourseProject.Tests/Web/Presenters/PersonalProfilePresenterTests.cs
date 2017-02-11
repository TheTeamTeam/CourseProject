using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CourseProject.Tests.Web.Presenters.Mocks;
using CourseProject.Services.Contracts;
using CourseProject.Web.Presenters;
using CourseProject.Web.EventArguments;
using CourseProject.Models;

namespace CourseProject.Tests.Web.Presenters
{
    [TestFixture]
    public class PersonalProfilePresenterTests
    {    
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenUserServiceIsNull()
        {
            var mockedView = new MockedPersonalProfileView();

            Assert.Throws<ArgumentNullException>(() => new PersonalProfilePresenter(mockedView, null));
        }

        [Test]
        public void Constructor_ShouldThrowExceptionWithCorrectMessage_WhenUserServiceIsNull()
        {
            var mockedView = new MockedPersonalProfileView();

            Assert.That(() => new PersonalProfilePresenter(mockedView, null),
                    Throws.ArgumentNullException.With.Message.Contains("Users service cannot be null."));
        }

        [Test]
        public void Constructor_ShouldAttachEventToViewGettingUser()
        {
            var mockedView = new MockedPersonalProfileView();
            var mockedService = new Mock<IUsersService>();
            var presenter = new PersonalProfilePresenter(mockedView, mockedService.Object);

            Assert.IsTrue(mockedView.IsSubscribedGettingUser("OnGettingUser"));
        }

        [Test]
        public void OnGettingUser_ShouldCallUserServiceGetUserById()
        {
            var mockedView = new MockedPersonalProfileView();
            var mockedService = new Mock<IUsersService>();
            mockedService.Setup(x => x.GetUserById(It.IsAny<string>())).Verifiable();
            var presenter = new PersonalProfilePresenter(mockedView, mockedService.Object);

            mockedView.InvokeGettingUser(mockedView, new Mock<GetUserByIdEventArgs>("id").Object);

            mockedService.Verify(x=>x.GetUserById(It.IsAny<string>()), Times.Once);            
        }

        // TODO: Relies on the agrs contructor, maybe extract interface ??
        [TestCase("hwoeifho4355")]
        [TestCase("the_id")]
        public void OnGettingUser_ShouldCallGetUserByIdWithCorrectParameter(string id)
        {
            var mockedView = new MockedPersonalProfileView();
            var mockedService = new Mock<IUsersService>();
            mockedService.Setup(x => x.GetUserById(It.IsAny<string>())).Verifiable();
            var presenter = new PersonalProfilePresenter(mockedView, mockedService.Object);
            var eventArgs = new Mock<GetUserByIdEventArgs>(id);

            mockedView.InvokeGettingUser(mockedView, eventArgs.Object);

            mockedService.Verify(x => x.GetUserById(id), Times.Once);
        }

        [Test]
        public void OnGettingUser_ShouldSetModelUserCorrectly()
        {
            var mockedView = new MockedPersonalProfileView();
            var mockedService = new Mock<IUsersService>();
            var mockedUser = new Mock<User>();
            mockedService.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(mockedUser.Object);
            var presenter = new PersonalProfilePresenter(mockedView, mockedService.Object);
            var eventArgs = new Mock<GetUserByIdEventArgs>("id");

            mockedView.InvokeGettingUser(mockedView, eventArgs.Object);

            Assert.AreEqual(mockedUser.Object, mockedView.Model.ProfileUser);
        }
    }
}
