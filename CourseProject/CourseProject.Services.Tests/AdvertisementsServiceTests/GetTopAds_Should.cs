using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;
using Moq;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Data.Repositories;
using CourseProject.Models;

namespace CourseProject.Services.Tests.AdvertisementsServiceTests
{
    [TestFixture]
    public class GetTopAds_Should
    {
        [Test]
        public void CallRepositoryGetAllMethodWithFilterAndSortExpression()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var mock1 = new Mock<Advertisement>();
            var mock2 = new Mock<Advertisement>();
            var mock3 = new Mock<Advertisement>();
            var mock4 = new Mock<Advertisement>();
            var data = new List<Advertisement>()
            {
                mock1.Object,
                mock2.Object,
                mock3.Object,
                mock4.Object
            };
            mockedAdsRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<Advertisement, bool>>>(), It.IsAny<Expression<Func<Advertisement, DateTime>>>())).Returns(data);

            var adsService = new AdvertisementsService(mockedUnitOfWork.Object, mockedAdsRepo.Object);

            adsService.GetTopAds(5);

            mockedAdsRepo.Verify(x => x.GetAll(It.IsAny<Expression<Func<Advertisement, bool>>>(), It.IsAny<Expression<Func<Advertisement, DateTime>>>()), Times.Once);
        }

        [Test]
        public void ReturnTheGivenCountOfObjects()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            var mock1 = new Mock<Advertisement>();
            var mock2 = new Mock<Advertisement>();
            var mock3 = new Mock<Advertisement>();
            var mock4 = new Mock<Advertisement>();
            var data = new List<Advertisement>()
            {
                mock1.Object,
                mock2.Object,
                mock3.Object,
                mock4.Object
            };
            mockedAdsRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<Advertisement, bool>>>(), It.IsAny<Expression<Func<Advertisement, DateTime>>>())).Returns(data);
            var count = 3;

            var adsService = new AdvertisementsService(mockedUnitOfWork.Object, mockedAdsRepo.Object);

            var result =adsService.GetTopAds(count);

            Assert.AreEqual(count, result.Count());
            CollectionAssert.AreEqual(data.Take(count), result);
        }
    }
}
