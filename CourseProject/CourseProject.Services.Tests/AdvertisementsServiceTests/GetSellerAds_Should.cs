using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using CourseProject.Data.UnitsOfWork;
using CourseProject.Data.Repositories;
using CourseProject.Models;
using System.Linq.Expressions;

namespace CourseProject.Services.Tests.AdvertisementsServiceTests
{
    class GetSellerAds_Should
    {
        [Test]
        public void CallRepositoryGetAllMethodWithFilter()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
            mockedAdsRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<Advertisement, bool>>>())).Returns(new List<Advertisement>());
            var id = "the_seller_id_12345465";

            var adsService = new AdvertisementsService(mockedUnitOfWork.Object, mockedAdsRepo.Object);

            adsService.GetSellerAds(id);

            mockedAdsRepo.Verify(x => x.GetAll(It.IsAny<Expression<Func<Advertisement, bool>>>()), Times.Once);
        }

        [Test]
        public void ReturnTheResultFromTheRepositoryMethod()
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
            mockedAdsRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<Advertisement, bool>>>())).Returns(data);
            var id = "the_seller_id_12345465";

            var adsService = new AdvertisementsService(mockedUnitOfWork.Object, mockedAdsRepo.Object);

            var result = adsService.GetSellerAds(id);

            CollectionAssert.AreEqual(data, result);
        }
    }
}
