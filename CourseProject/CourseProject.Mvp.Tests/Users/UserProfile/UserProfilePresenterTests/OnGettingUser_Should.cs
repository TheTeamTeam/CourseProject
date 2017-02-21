using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using NUnit.Framework;
using Moq;
using CourseProject.Models;
using CourseProject.Mvp.Users.UserProfile;
using CourseProject.Services.Contracts;
using System.Web;
using System.IO;

namespace CourseProject.Mvp.Tests.Users.UserProfile.UserProfilePresenterTests
{
    [TestFixture]
    public class OnGettingUser_Should
    {
        //[Test]
        //public void CallUserServiceGetUserByUsername()
        //{
        //    var model = new UserProfileModel();
        //    var mockedView = new Mock<IUserProfileView>();
        //    var mockedAdsService = new Mock<IAdvertisementsService>();
        //    var mockedUsersService = new Mock<IUsersService>();

        //    mockedView.Setup(x => x.Model).Returns(model);
        //    mockedView.Setup(x => x.User).Returns(new Mock<IPrincipal>().Object);
        //    mockedUsersService.Setup(x => x.GetUserByUsername(It.IsAny<string>())).Returns(new User());
        //    var presenter = new UserProfilePresenter(mockedView.Object, mockedUsersService.Object, mockedAdsService.Object);
        //    var request = new HttpRequest("filename", "http://localhost", "");
        //    var writer = new Mock<TextWriter>();
        //    var response = new HttpResponse(writer.Object);
        //    var context = new HttpContext(request, response);
        //    var eventArgs = new GetUserByUsernameEventArgs("username", context);

        //    mockedView.Raise(x => x.GettingUser += null, eventArgs);
            
        //    mockedUsersService.Verify(x => x.GetUserByUsername(It.IsAny<string>()), Times.Once);
        //}

        [Test]
        public void CallUserServiceGetUserByUsernameWithCorrectUsername()
        {

        }

        [Test]
        public void TransferToNotFoundWhenUserIsNull()
        {

        }

        [Test]
        public void ReturnWhenUserIsNull()
        {

        }

        [Test]
        public void ReturnWhenCurrentUserIsNotAdminAndOtherUserIsNotSeller()
        {

        }

        [Test]
        public void GetSellerAdsWhenUserIsSeller()
        {

        }

        [Test]
        public void NotCallGetSellerAdsWhenUserIsNotSeller()
        {
            var user = new User();
        }
    }
}
