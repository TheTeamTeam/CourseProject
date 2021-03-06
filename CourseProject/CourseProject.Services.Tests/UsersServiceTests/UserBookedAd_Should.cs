﻿using NUnit.Framework;
using Moq;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Data.Repositories;
using CourseProject.Models;

namespace CourseProject.Services.Tests.UsersServiceTests
{
    [TestFixture]
    public class UserBookedAd_Should
    {
        [Test]
        public void CallUsersRepositoryMethod()
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
        public void CallUsersRepositoryMethodWithCorrectId(string id)
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
        public void CallUsersUpcomingAdsContainsMethod()
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
        public void CallUsersUsersUpcomingAdsContainsWithCorrectAd()
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
        public void ReturnCorrectResult()
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
    }                                  
}
