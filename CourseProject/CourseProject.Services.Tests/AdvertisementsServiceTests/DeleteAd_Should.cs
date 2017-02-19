using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Data.Repositories;
using CourseProject.Models;

namespace CourseProject.Services.Tests.AdvertisementsServiceTests
{
    [TestFixture]
    public class DeleteAd_Should
    {
        [TestCase(5)]
        [TestCase(437486)]
        public void CallAdsRepositoryGetByIdMethodWithCorrectId(int id)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedAdsRepo.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.DeleteAd(id);

            mockedAdsRepo.Verify(x => x.GetById(id), Times.Once);
        }

        [Test]
        public void CallAdsRepositoryDeleteMethodWithCorrectAd()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var mockedAd = new Mock<Advertisement>();
            mockedAdsRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedAd.Object);
            mockedAdsRepo.Setup(x => x.Delete(It.IsAny<Advertisement>())).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.DeleteAd(12345);

            mockedAdsRepo.Verify(x => x.Delete(mockedAd.Object), Times.Once);
        }

        [Test]
        public void CallUnitOfWorkCommitMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.DeleteAd(123);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
