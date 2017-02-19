using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Data.Repositories;
using CourseProject.Models;

namespace CourseProject.Services.Tests.AdvertisementsServiceTests
{
    [TestFixture]
    public class GetAdvertisements_Should
    {
        [Test]
        public void CallAdvertisementsRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedAdsRepo.Setup(x => x.GetAll()).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.GetAdvertisements();

            mockedAdsRepo.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void ReturnTheResultFromTheRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var expected = new List<Advertisement>()
            {
                new Mock<Advertisement>().Object,
                new Mock<Advertisement>().Object,
                new Mock<Advertisement>().Object
            };

            mockedAdsRepo.Setup(x => x.GetAll()).Returns(expected);

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            var result = service.GetAdvertisements();

            Assert.AreEqual(expected, result);
        }
    }
}
