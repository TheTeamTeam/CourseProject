using NUnit.Framework;
using Moq;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Data.Repositories;
using CourseProject.Models;

namespace CourseProject.Services.Tests.AdvertisementsServiceTests
{
    [TestFixture]
    public class DecrementFreePlaces_Should
    {
        [Test]
        public void DecrementAdsPlaces()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var ad = new Advertisement();
            var places = 15;

            ad.Places = places;

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.DecrementFreePlaces(ad);

            Assert.AreEqual(places - 1, ad.Places);
        }

        [Test]
        public void CallAdsRepositoryUpdateMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedAdsRepo.Setup(x => x.Update(It.IsAny<Advertisement>())).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.DecrementFreePlaces(new Mock<Advertisement>().Object);

            mockedAdsRepo.Verify(x => x.Update(It.IsAny<Advertisement>()), Times.Once);
        }

        [Test]
        public void CallAdsRepositoryMethodWithCorrectParameter()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var ad = new Mock<Advertisement>();

            mockedAdsRepo.Setup(x => x.Update(It.IsAny<Advertisement>())).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.DecrementFreePlaces(ad.Object);

            mockedAdsRepo.Verify(x => x.Update(ad.Object), Times.Once);
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

            service.DecrementFreePlaces(new Mock<Advertisement>().Object);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }


        [Test]
        public void DecrementFreePlaces_ShouldCallUnitOfWorkDisposeMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedUnitOfWork.Setup(x => x.Dispose()).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.DecrementFreePlaces(new Mock<Advertisement>().Object);

            mockedUnitOfWork.Verify(x => x.Dispose(), Times.Once);
        }
    }
}
