using System;
using Moq;
using NUnit.Framework;
using CourseProject.Data.Repositories;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Models;

namespace CourseProject.Services.Tests.AdvertisementsServiceTests
{
    [TestFixture]
    public class Contructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            Assert.Throws<ArgumentNullException>(() => new AdvertisementsService(null, mockedAdsRepo.Object));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenUnitOfWorkIsNull()
        {
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            Assert.That(() => new AdvertisementsService(null, mockedAdsRepo.Object),
                Throws.ArgumentNullException.With.Message.Contains("Unit of work cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenAdsRepoIsNull()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(() => new AdvertisementsService(mockedUnitOfWork.Object, null));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenAdsRepoIsNull()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.That(() => new AdvertisementsService(mockedUnitOfWork.Object, null),
                Throws.ArgumentNullException.With.Message.Contains("Ads repository cannot be null."));
        }
    }
}
