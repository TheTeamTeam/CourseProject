using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Data.Repositories;
using CourseProject.Models;

namespace CourseProject.Services.Tests.UsersServiceTests
{
    [TestFixture]
    public class AddAdToSaved_Should
    {
        [Test]
        public void CallUsersRepositoryMethod()
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
        public void CallUsersRepositoryMethodWithCorrectId(string id)
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
        public void CallUserSavedAdsAddMethod()
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
        public void CallUserSavedAdsAddMethodWithCorrectAd()
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
        public void CallUnitOfWorkCommitMethod()
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
        public void CallUnitOfWorkDisposeMethod()
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
    }
}
