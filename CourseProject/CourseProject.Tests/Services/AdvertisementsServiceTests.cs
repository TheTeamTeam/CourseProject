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
using CourseProject.Services;

namespace CourseProject.Tests.Services
{
    [TestFixture]
    public class AdvertisementsServiceTests
    {
        [Test]
        public void GetById_ShouldCallAdsRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedAdsRepo.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedCategoriesRepo.Object, 
                mockedCitiesRepo.Object, 
                mockedAdsRepo.Object);

            service.GetAdById(1);

            mockedAdsRepo.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [TestCase(5)]
        [TestCase(437486)]
        public void GetById_ShouldCallAdsRepositoryMethodWithCorrectId(int id)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedAdsRepo.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedCategoriesRepo.Object,
                mockedCitiesRepo.Object,
                mockedAdsRepo.Object);

            service.GetAdById(id);

            mockedAdsRepo.Verify(x => x.GetById(id), Times.Once);
        }

        [Test]
        public void GetById_ShouldReturnTheResultFromTheRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var mockedAd = new Mock<Advertisement>();

            mockedAdsRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedAd.Object);

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedCategoriesRepo.Object,
                mockedCitiesRepo.Object,
                mockedAdsRepo.Object);

            var result = service.GetAdById(123455);

            Assert.AreEqual(mockedAd.Object, result);
        }

        [Test]
        public void GetCategories_ShouldCallCategoriesRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedCategoriesRepo.Setup(x => x.GetAll()).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedCategoriesRepo.Object,
                mockedCitiesRepo.Object,
                mockedAdsRepo.Object);

            service.GetCategories();

            mockedCategoriesRepo.Verify(x => x.GetAll(), Times.Once);
        }
        
        [Test]
        public void GetCategories_ShouldReturnTheResultFromTheRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var expected = new List<Category>()
            {
                new Mock<Category>().Object,
                new Mock<Category>().Object,
                new Mock<Category>().Object
            };

            mockedCategoriesRepo.Setup(x => x.GetAll()).Returns(expected);

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedCategoriesRepo.Object,
                mockedCitiesRepo.Object,
                mockedAdsRepo.Object);

            var result = service.GetCategories();

            Assert.AreEqual(expected, result);
        }
            
        [Test]
        public void GetCities_ShouldCallCitiesRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedCitiesRepo.Setup(x => x.GetAll()).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedCategoriesRepo.Object,
                mockedCitiesRepo.Object,
                mockedAdsRepo.Object);

            service.GetCities();

            mockedCitiesRepo.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void GetCities_ShouldReturnTheResultFromTheRepositoryMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var expected = new List<City>()
            {
                new Mock<City>().Object,
                new Mock<City>().Object,
                new Mock<City>().Object
            };

            mockedCitiesRepo.Setup(x => x.GetAll()).Returns(expected);

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedCategoriesRepo.Object,
                mockedCitiesRepo.Object,
                mockedAdsRepo.Object);

            var result = service.GetCities();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CreateAdvertisement_ShouldCallAdsRepositoryAddMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedAdsRepo.Setup(x => x.Add(It.IsAny<Advertisement>())).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedCategoriesRepo.Object,
                mockedCitiesRepo.Object,
                mockedAdsRepo.Object);

            service.CreateAdvertisement(new Mock<Advertisement>().Object);

            mockedAdsRepo.Verify(x => x.Add(It.IsAny<Advertisement>()), Times.Once);
        }

        [Test]
        public void CreateAdvertisement_ShouldCallAdsRepositoryMethodWithCorrectParameter()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var mockedAd = new Mock<Advertisement>();

            mockedAdsRepo.Setup(x => x.Add(It.IsAny<Advertisement>())).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedCategoriesRepo.Object,
                mockedCitiesRepo.Object,
                mockedAdsRepo.Object);

            service.CreateAdvertisement(mockedAd.Object);

            mockedAdsRepo.Verify(x => x.Add(mockedAd.Object), Times.Once);
        }

        [Test]
        public void CreateAdvertisement_ShouldCallUnitOfWorkCommitMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedCategoriesRepo.Object,
                mockedCitiesRepo.Object,
                mockedAdsRepo.Object);

            service.CreateAdvertisement(new Mock<Advertisement>().Object);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void CreateAdvertisement_ShouldCallUnitOfWorkDisposeMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedUnitOfWork.Setup(x => x.Dispose()).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedCategoriesRepo.Object,
                mockedCitiesRepo.Object,
                mockedAdsRepo.Object);

            service.CreateAdvertisement(new Mock<Advertisement>().Object);

            mockedUnitOfWork.Verify(x => x.Dispose(), Times.Once);
        }


        // TODO: interfaces for models or ??
        // [Test]
        //public void DecrementFreePlaces_ShouldDecrementAdsPlaces()
        //{
        //    var mockedUnitOfWork = new Mock<IUnitOfWork>();
        //    var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
        //    var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
        //    var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
        //    var mockedAd = new Mock<Advertisement>();
        //    var places = 15;

        //    mockedAd.SetupGet(x => x.Places).Returns(places);
        //    mockedAd.SetupSet(x => x.Places = It.IsAny<int>()).Verifiable();
            
        //    var service = new AdvertisementsService(
        //        mockedUnitOfWork.Object,
        //        mockedCategoriesRepo.Object,
        //        mockedCitiesRepo.Object,
        //        mockedAdsRepo.Object);

        //    service.DecrementFreePlaces(mockedAd.Object);

        //    mockedAd.VerifySet(x => x.Places = places - 1, Times.Once);
        //}

        [Test]
        public void DecrementFreePlaces_ShouldCallAdsRepositoryUpdateMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedAdsRepo.Setup(x => x.Update(It.IsAny<Advertisement>())).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedCategoriesRepo.Object,
                mockedCitiesRepo.Object,
                mockedAdsRepo.Object);

            service.DecrementFreePlaces(new Mock<Advertisement>().Object);

            mockedAdsRepo.Verify(x => x.Update(It.IsAny<Advertisement>()), Times.Once);
        }

        [Test]
        public void DecrementFreePlaces_ShouldCallAdsRepositoryMethodWithCorrectParameter()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var ad = new Mock<Advertisement>();

            mockedAdsRepo.Setup(x => x.Update(It.IsAny<Advertisement>())).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedCategoriesRepo.Object,
                mockedCitiesRepo.Object,
                mockedAdsRepo.Object);

            service.DecrementFreePlaces(ad.Object);

            mockedAdsRepo.Verify(x => x.Update(ad.Object), Times.Once);
        }

        [Test]
        public void DecrementFreePlaces_ShouldCallUnitOfWorkCommitMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedCategoriesRepo.Object,
                mockedCitiesRepo.Object,
                mockedAdsRepo.Object);

            service.DecrementFreePlaces(new Mock<Advertisement>().Object);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void DecrementFreePlaces_ShouldCallUnitOfWorkDisposeMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedUnitOfWork.Setup(x => x.Dispose()).Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedCategoriesRepo.Object,
                mockedCitiesRepo.Object,
                mockedAdsRepo.Object);

            service.DecrementFreePlaces(new Mock<Advertisement>().Object);

            mockedUnitOfWork.Verify(x => x.Dispose(), Times.Once);
        }
    }
}
