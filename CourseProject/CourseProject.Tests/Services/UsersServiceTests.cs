using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using CourseProject.Data.Repositories;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Models;
using CourseProject.Services;

namespace CourseProject.Tests.Services
{
    [TestFixture]
    public class UsersServiceTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();

            Assert.Throws<ArgumentNullException>(() => new UsersService(null, mockedUsersRepo.Object));
        }

        [Test]
        public void Constructor_ShouldThrowExceptionWithCorrectMessage_WhenUnitOfWorkIsNull()
        {
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();

            Assert.That(() => new UsersService(null, mockedUsersRepo.Object),
                Throws.ArgumentNullException.With.Message.Contains("Unit of work cannot be null."));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenUsersRepoIsNull()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(() => new UsersService(mockedUnitOfWork.Object, null));
        }

        [Test]
        public void Constructor_ShouldThrowExceptionWithCorrectMessage_WhenUsersRepoIsNull()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.That(() => new UsersService(mockedUnitOfWork.Object, null),
                Throws.ArgumentNullException.With.Message.Contain("Users repository cannot be null."));
        }

        [Test]
        public void GetUserById_ShouldCallUsersRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();

            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Verifiable();

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.GetUserById("1");

            mockedUsersRepo.Verify(x => x.GetById(It.IsAny<string>()), Times.Once);
        }

        [TestCase("1a")]
        [TestCase("1a2b3c4d")]
        public void GetUserById_ShouldCallUsersRepositoryMethodWithCorrectId(string id)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();

            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Verifiable();

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.GetUserById(id);

            mockedUsersRepo.Verify(x => x.GetById(id), Times.Once);
        }

        [Test]
        public void GetUserById_ShouldReturnTheResultFromTheRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedUser = new Mock<User>();

            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            var result = service.GetUserById("12345a");

            Assert.AreEqual(mockedUser.Object, result);
        }

        [Test]
        public void AddAdToUpcoming_ShouldCallUsersRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.UpcomingAds).Returns(new List<Advertisement>());
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Verifiable();
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.AddAdToUpcoming("1", mockedAd.Object);

            mockedUsersRepo.Verify(x => x.GetById(It.IsAny<string>()), Times.Once);
        }

        [TestCase("1aa")]
        [TestCase("2bb")]
        public void AddAdToUpcoming_ShouldCallUsersRepositoryMethodWithCorrectId(string id)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.UpcomingAds).Returns(new List<Advertisement>());
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Verifiable();
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.AddAdToUpcoming(id, mockedAd.Object);

            mockedUsersRepo.Verify(x => x.GetById(id), Times.Once);
        }

        [Test]
        public void AddAdToUpcoming_ShouldCallUserUpcomingAdsAddMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.UpcomingAds.Add(It.IsAny<Advertisement>())).Verifiable();
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.AddAdToUpcoming("1", mockedAd.Object);

            mockedUser.Verify(x => x.UpcomingAds.Add(It.IsAny<Advertisement>()), Times.Once);
        }

        [Test]
        public void AddAdToUpcoming_ShouldCallUserUpcomingAdsAddMethodWithCorrectAd()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.UpcomingAds.Add(It.IsAny<Advertisement>())).Verifiable();
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.AddAdToUpcoming("1", mockedAd.Object);

            mockedUser.Verify(x => x.UpcomingAds.Add(mockedAd.Object), Times.Once);
        }

        [Test]
        public void AddAdToUpcoming_ShouldCallUnitOfWorkCommitMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.UpcomingAds).Returns(new List<Advertisement>());
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);
            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.AddAdToUpcoming("123a", mockedAd.Object);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void AddAdToUpcoming_ShouldCallUnitOfWorkDisposeMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.UpcomingAds).Returns(new List<Advertisement>());
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);
            mockedUnitOfWork.Setup(x => x.Dispose()).Verifiable();

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.AddAdToUpcoming("123a", mockedAd.Object);

            mockedUnitOfWork.Verify(x => x.Dispose(), Times.Once);
        }

        [Test]
        public void AddAdToSaved_ShouldCallUsersRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.SavedAds).Returns(new List<Advertisement>());
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Verifiable();
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.AddAdToSaved("1", mockedAd.Object);

            mockedUsersRepo.Verify(x => x.GetById(It.IsAny<string>()), Times.Once);
        }

        [TestCase("1aa")]
        [TestCase("2bb")]
        public void AddAdToSaved_ShouldCallUsersRepositoryMethodWithCorrectId(string id)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.SavedAds).Returns(new List<Advertisement>());
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Verifiable();
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.AddAdToSaved(id, mockedAd.Object);

            mockedUsersRepo.Verify(x => x.GetById(id), Times.Once);
        }

        [Test]
        public void AddAdToSaved_ShouldCallUserSavedAdsAddMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.SavedAds.Add(It.IsAny<Advertisement>())).Verifiable();
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.AddAdToSaved("1", mockedAd.Object);

            mockedUser.Verify(x => x.SavedAds.Add(It.IsAny<Advertisement>()), Times.Once);
        }

        [Test]
        public void AddAdToSaved_ShouldCallUserSavedAdsAddMethodWithCorrectAd()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.SavedAds.Add(It.IsAny<Advertisement>())).Verifiable();
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.AddAdToSaved("1", mockedAd.Object);

            mockedUser.Verify(x => x.SavedAds.Add(mockedAd.Object), Times.Once);
        }

        [Test]
        public void AddAdToSaved_ShouldCallUnitOfWorkCommitMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.SavedAds).Returns(new List<Advertisement>());
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);
            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.AddAdToSaved("123a", mockedAd.Object);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void AddAdToSaved_ShouldCallUnitOfWorkDisposeMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.SavedAds).Returns(new List<Advertisement>());
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);
            mockedUnitOfWork.Setup(x => x.Dispose()).Verifiable();

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.AddAdToSaved("123a", mockedAd.Object);

            mockedUnitOfWork.Verify(x => x.Dispose(), Times.Once);
        }

        [Test]
        public void UserBookedAd_ShouldCallUsersRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.UpcomingAds.Contains(It.IsAny<Advertisement>())).Returns(true);
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Verifiable();
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.UserBookedAd("1a2b3c", mockedAd.Object);

            mockedUsersRepo.Verify(x => x.GetById(It.IsAny<string>()), Times.Once);
        }

        [TestCase("1aa")]
        [TestCase("2bb")]
        public void UserBookedAd_ShouldCallUsersRepositoryMethodWithCorrectId(string id)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.UpcomingAds.Contains(It.IsAny<Advertisement>())).Returns(true);
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Verifiable();
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.UserBookedAd(id, mockedAd.Object);

            mockedUsersRepo.Verify(x => x.GetById(id), Times.Once);
        }

        [Test]
        public void UserBookedAd_ShouldCallUsersUpcomingAdsContainsMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.UpcomingAds.Contains(It.IsAny<Advertisement>())).Verifiable();
            mockedUser.Setup(x => x.UpcomingAds.Contains(It.IsAny<Advertisement>())).Returns(true);
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.UserBookedAd("1111abc", mockedAd.Object);

            mockedUser.Verify(x => x.UpcomingAds.Contains(It.IsAny<Advertisement>()), Times.Once);
        }

        [Test]
        public void UserBookedAd_ShouldCallUsersUsersUpcomingAdsContainsWithCorrectAd()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.UpcomingAds.Contains(It.IsAny<Advertisement>())).Verifiable();
            mockedUser.Setup(x => x.UpcomingAds.Contains(It.IsAny<Advertisement>())).Returns(true);
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.UserBookedAd("1a2", mockedAd.Object);

            mockedUser.Verify(x => x.UpcomingAds.Contains(mockedAd.Object), Times.Once);
        }

        [Test]
        public void UserBookedAd_ShouldReturnCorrectResult()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();
            bool expected = true;

            mockedUser.Setup(x => x.UpcomingAds.Contains(It.IsAny<Advertisement>())).Returns(expected);
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            var result = service.UserBookedAd("1a2", mockedAd.Object);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void UserSavedAd_ShouldCallUsersRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.SavedAds.Contains(It.IsAny<Advertisement>())).Returns(true);
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Verifiable();
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.UserSavedAd("1a2b3c", mockedAd.Object);

            mockedUsersRepo.Verify(x => x.GetById(It.IsAny<string>()), Times.Once);
        }

        [TestCase("1aa")]
        [TestCase("2bb")]
        public void UserSavedAd_ShouldCallUsersRepositoryMethodWithCorrectId(string id)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.SavedAds.Contains(It.IsAny<Advertisement>())).Returns(true);
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Verifiable();
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.UserSavedAd(id, mockedAd.Object);

            mockedUsersRepo.Verify(x => x.GetById(id), Times.Once);
        }

        [Test]
        public void UserSavedAd_ShouldCallUsersUpcomingAdsContainsMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.SavedAds.Contains(It.IsAny<Advertisement>())).Verifiable();
            mockedUser.Setup(x => x.SavedAds.Contains(It.IsAny<Advertisement>())).Returns(true);
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.UserSavedAd("1111abc", mockedAd.Object);

            mockedUser.Verify(x => x.SavedAds.Contains(It.IsAny<Advertisement>()), Times.Once);
        }

        [Test]
        public void UserSavedAd_ShouldCallUsersUsersUpcomingAdsContainsWithCorrectAd()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();

            mockedUser.Setup(x => x.SavedAds.Contains(It.IsAny<Advertisement>())).Verifiable();
            mockedUser.Setup(x => x.SavedAds.Contains(It.IsAny<Advertisement>())).Returns(true);
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            service.UserSavedAd("1a2", mockedAd.Object);

            mockedUser.Verify(x => x.SavedAds.Contains(mockedAd.Object), Times.Once);
        }

        [Test]
        public void UserSavedAd_ShouldReturnCorrectResult()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUsersRepo = new Mock<IGenericRepository<User>>();
            var mockedAd = new Mock<Advertisement>();
            var mockedUser = new Mock<User>();
            bool expected = true;

            mockedUser.Setup(x => x.SavedAds.Contains(It.IsAny<Advertisement>())).Returns(expected);
            mockedUsersRepo.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var service = new UsersService(
                mockedUnitOfWork.Object,
                mockedUsersRepo.Object);

            var result = service.UserSavedAd("1a2", mockedAd.Object);

            Assert.AreEqual(expected, result);
        }
    }
}
