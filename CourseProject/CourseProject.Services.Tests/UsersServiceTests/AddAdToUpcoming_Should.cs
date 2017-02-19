using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Data.Repositories;
using CourseProject.Models;

namespace CourseProject.Services.Tests.UsersServiceTests
{
    [TestFixture]
    public class AddAdToUpcoming_Should
    {
        [Test]
        public void CallUsersRepositoryMethod()
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
        public void CallUsersRepositoryMethodWithCorrectId(string id)
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
        public void CallUserUpcomingAdsAddMethod()
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
        public void CallUserUpcomingAdsAddMethodWithCorrectAd()
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
        public void CallUnitOfWorkCommitMethod()
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
        public void CallUnitOfWorkDisposeMethod()
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
    }
}
