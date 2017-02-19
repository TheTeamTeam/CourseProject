using NUnit.Framework;
using Moq;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Data.Repositories;
using CourseProject.Models;

namespace CourseProject.Services.Tests.AdvertisementsServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void CallAdsRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedAdsRepo.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.GetAdById(1);

            mockedAdsRepo.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [TestCase(5)]
        [TestCase(437486)]
        public void CallAdsRepositoryMethodWithCorrectId(int id)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedAdsRepo.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.GetAdById(id);

            mockedAdsRepo.Verify(x => x.GetById(id), Times.Once);
        }

        [Test]
        public void ReturnTheResultFromTheRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var mockedAd = new Mock<Advertisement>();

            mockedAdsRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedAd.Object);

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            var result = service.GetAdById(123455);

            Assert.AreEqual(mockedAd.Object, result);
        }
    }
}
