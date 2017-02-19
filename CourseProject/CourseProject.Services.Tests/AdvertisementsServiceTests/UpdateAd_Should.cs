using NUnit.Framework;
using Moq;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Data.Repositories;
using CourseProject.Models;

namespace CourseProject.Services.Tests.AdvertisementsServiceTests
{
    [TestFixture]
    public class UpdateAd_Should
    {
        [Test]
        public void CallAdsRepositoryUpdateMethodWithCorrectAd()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var mockedAd = new Mock<Advertisement>();
            mockedAdsRepo.Setup(x => x.Update(It.IsAny<Advertisement>())).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.UpdateAd(mockedAd.Object);

            mockedAdsRepo.Verify(x => x.Update(mockedAd.Object), Times.Once);
        }

        [Test]
        public void CallUnitOfWorkCommitMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var mockedAd = new Mock<Advertisement>();

            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.UpdateAd(mockedAd.Object);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
