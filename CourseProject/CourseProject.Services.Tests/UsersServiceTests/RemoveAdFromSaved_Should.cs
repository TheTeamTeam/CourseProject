using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Data.Repositories;
using CourseProject.Models;

namespace CourseProject.Services.Tests.UsersServiceTests
{
    [TestFixture]
    public class RemoveAdFromSaved_Should
    {
        [Test]
        public void RemovesTheAdWithCorrectIdFromUserSavedAds()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<User>>();
            var mockedUser = new Mock<User>();
            var matchingAd = new Advertisement();
            var mockedAd = new Mock<Advertisement>();

            var adId = 55324;
            matchingAd.Id = adId;
            var data = new List<Advertisement> { matchingAd, mockedAd.Object };
            mockedUser.Setup(x => x.SavedAds).Returns(data);

            var service = new UsersService(mockedUnitOfWork.Object, mockedAdsRepo.Object);

            service.RemoveAdFromSaved(adId, mockedUser.Object);

            CollectionAssert.DoesNotContain(data, matchingAd);
        }

        [Test]
        public void CallUnitOfWorkCommitMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<User>>();
            var mockedUser = new Mock<User>();
            mockedUser.Setup(x => x.SavedAds).Returns(new List<Advertisement>());
            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();

            var service = new UsersService(mockedUnitOfWork.Object, mockedAdsRepo.Object);

            service.RemoveAdFromSaved(123, mockedUser.Object);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
