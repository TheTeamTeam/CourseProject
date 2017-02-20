using NUnit.Framework;
using Moq;
using CourseProject.Services.Contracts;
using CourseProject.Mvp.Users.PersonalProfile;
using CourseProject.Models;
using System.Collections.Generic;

namespace CourseProject.Mvp.Tests.Users.PersonalProfile.PersonalProfilePresenterTests
{
    [TestFixture]
    public class OnGettingUser_Should
    {
        [Test]
        public void CallUserServiceGetUserById()
        {
            var model = new PersonalProfileModel();
            var mockedView = new Mock<IPersonalProfileView>();
            var mockedService = new Mock<IUsersService>();
            var mockedAdsService = new Mock<IAdvertisementsService>();

            mockedView.Setup(x => x.Model).Returns(model);
            mockedService.Setup(x => x.GetUserById(It.IsAny<string>())).Verifiable();

            var presenter = new PersonalProfilePresenter(mockedView.Object, mockedService.Object, mockedAdsService.Object);
            var eventArgs = new GetUserByIdEventArgs("id", false);

            mockedView.Raise(x => x.GettingUser += null, eventArgs);

            mockedService.Verify(x => x.GetUserById(It.IsAny<string>()), Times.Once);
        }

        [TestCase("hwoeifho4355")]
        [TestCase("the_id")]
        public void CallGetUserByIdWithCorrectParameter(string id)
        {
            var model = new PersonalProfileModel();
            var mockedView = new Mock<IPersonalProfileView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();

            mockedView.Setup(x => x.Model).Returns(model);
            mockedUsersService.Setup(x => x.GetUserById(It.IsAny<string>())).Verifiable();

            var presenter = new PersonalProfilePresenter(mockedView.Object, mockedUsersService.Object, mockedAdsService.Object);
            var eventArgs = new GetUserByIdEventArgs(id, false);

            mockedView.Raise(x => x.GettingUser += null, eventArgs);

            mockedUsersService.Verify(x => x.GetUserById(id), Times.Once);
        }

        [Test]
        public void SetModelUserCorrectly()
        {
            var model = new PersonalProfileModel();
            var mockedView = new Mock<IPersonalProfileView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();

            mockedView.Setup(x => x.Model).Returns(model);
            var mockedUser = new Mock<User>();
            mockedUsersService.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(mockedUser.Object);

            var presenter = new PersonalProfilePresenter(mockedView.Object, mockedUsersService.Object, mockedAdsService.Object);
            var eventArgs = new GetUserByIdEventArgs("id", false);

            mockedView.Raise(x => x.GettingUser += null, eventArgs);

            Assert.AreEqual(mockedUser.Object, model.ProfileUser);
        }

        [Test]
        public void CallGetSellerAdsIfEventArgumentsIsSellerIsTrue()
        {
            var model = new PersonalProfileModel();
            var mockedView = new Mock<IPersonalProfileView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();

            mockedView.Setup(x => x.Model).Returns(model);
            mockedAdsService.Setup(x => x.GetSellerAds(It.IsAny<string>())).Verifiable();

            var presenter = new PersonalProfilePresenter(mockedView.Object, mockedUsersService.Object, mockedAdsService.Object);
            var id = "pesho";
            var eventArgs = new GetUserByIdEventArgs(id, true);

            mockedView.Raise(x => x.GettingUser += null, eventArgs);

            mockedAdsService.Verify(x => x.GetSellerAds(id), Times.Once);
        }

        [Test]
        public void SetModelSellerAdsIfEventArgumentsIsSellerIsTrue()
        {
            var model = new PersonalProfileModel();
            var mockedView = new Mock<IPersonalProfileView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedUsersService = new Mock<IUsersService>();

            mockedView.Setup(x => x.Model).Returns(model);

            var sellerAds = new List<Advertisement>()
            {
                new Mock<Advertisement>().Object,
                new Mock<Advertisement>().Object,
                new Mock<Advertisement>().Object
            };
            mockedAdsService.Setup(x => x.GetSellerAds(It.IsAny<string>())).Returns(sellerAds);

            var presenter = new PersonalProfilePresenter(mockedView.Object, mockedUsersService.Object, mockedAdsService.Object);
            var id = "pesho";
            var eventArgs = new GetUserByIdEventArgs(id, true);

            mockedView.Raise(x => x.GettingUser += null, eventArgs);

            CollectionAssert.AreEqual(sellerAds, model.SellerAds);
        }
    }
}
