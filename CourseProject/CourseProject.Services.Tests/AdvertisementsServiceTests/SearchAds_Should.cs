using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Data.Repositories;
using CourseProject.Models;
using System.Linq.Expressions;

namespace CourseProject.Services.Tests.AdvertisementsServiceTests
{
    [TestFixture]
    public class SearchAds_Should
    {
        [Test]
        public void CallRepostioryGetAllWithMultipleFiltersMethod()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

            mockedAdsRepo.Setup(
                x => x.GetAllWithMultipleFilters(
                    It.IsAny<IEnumerable<Expression<Func<Advertisement, bool>>>>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>()))
                .Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.SearchAds("e", "Name", 3, 4);

            mockedAdsRepo.Verify(
                x => x.GetAllWithMultipleFilters(
                    It.IsAny<IEnumerable<Expression<Func<Advertisement, bool>>>>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>()),
                Times.Once);
        }

        [Test]
        public void CallRepostioryGetAllWithCorrectOrder()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var order = "Places";
            mockedAdsRepo.Setup(
                x => x.GetAllWithMultipleFilters(
                    It.IsAny<IEnumerable<Expression<Func<Advertisement, bool>>>>(),
                    order,
                    It.IsAny<bool>()))
                .Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.SearchAds("e", order, 3, 4);

            mockedAdsRepo.Verify(
                x => x.GetAllWithMultipleFilters(
                    It.IsAny<IEnumerable<Expression<Func<Advertisement, bool>>>>(),
                    order,
                    It.IsAny<bool>()),
                Times.Once);
        }

        [Test]
        public void CallRepostioryGetAllWithIdAsOrderIfOrderIsNotACorrectProperty()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var notACorrectProperty = "NotAnAdProperty";
            mockedAdsRepo.Setup(
                x => x.GetAllWithMultipleFilters(
                    It.IsAny<IEnumerable<Expression<Func<Advertisement, bool>>>>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>()))
                .Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.SearchAds("e", notACorrectProperty, 3, 4);

            mockedAdsRepo.Verify(
                x => x.GetAllWithMultipleFilters(
                    It.IsAny<IEnumerable<Expression<Func<Advertisement, bool>>>>(),
                    "Id",
                    It.IsAny<bool>()),
                Times.Once);
        }

        [TestCase("Name", true)]
        [TestCase("Price", false)]
        public void CallRepostioryGetAllWithCorrectOrderDirection(string order, bool direction)
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            mockedAdsRepo.Setup(
                x => x.GetAllWithMultipleFilters(
                    It.IsAny<IEnumerable<Expression<Func<Advertisement, bool>>>>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>()))
                .Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.SearchAds("e", order, 3, 4);

            mockedAdsRepo.Verify(
                x => x.GetAllWithMultipleFilters(
                    It.IsAny<IEnumerable<Expression<Func<Advertisement, bool>>>>(),
                    order,
                    direction),
                Times.Once);
        }
        
        [Test]
        public void CallRepostioryIncludeMultipleMethodWithCorrectQuery()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var fakeQuery = new List<Advertisement>().AsQueryable();

            mockedAdsRepo.Setup(
                x => x.GetAllWithMultipleFilters(
                    It.IsAny<IEnumerable<Expression<Func<Advertisement, bool>>>>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>()))
                .Returns(fakeQuery);

            mockedAdsRepo.Setup(
                x => x.IncludeMultiple(
                    It.IsAny<IQueryable<Advertisement>>(),
                    It.IsAny<IEnumerable<Expression<Func<Advertisement, object>>>>()))
                .Verifiable();

            var service = new AdvertisementsService(
                mockedUnitOfWork.Object,
                mockedAdsRepo.Object);

            service.SearchAds("e", "Name", 3, 4);

            mockedAdsRepo.Verify(
                x => x.IncludeMultiple(
                    fakeQuery,
                    It.IsAny<IEnumerable<Expression<Func<Advertisement, object>>>>()),
                Times.Once);
        }
    }
}
