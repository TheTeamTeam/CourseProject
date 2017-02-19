using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Services.Tests.AdvertisementsServiceTests
{
    class OtherTests
    {
        // [Test]
        // public void SearchAds_ShouldCallAdsRepostoryGetAllMethod()
        // {
        //     var mockedUnitOfWork = new Mock<IUnitOfWork>();
        //     var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
        //     var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
        //     var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();

        //     mockedAdsRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<Advertisement, bool>>>())).Verifiable();

        //     var service = new AdvertisementsService(
        //         mockedUnitOfWork.Object,
        //         mockedCategoriesRepo.Object,
        //         mockedCitiesRepo.Object,
        //         mockedAdsRepo.Object);

        //     service.SearchAds("word");

        //     mockedAdsRepo.Verify(x => x.GetAll(It.IsAny<Expression<Func<Advertisement, bool>>>()), Times.Once);
        // }

        // TODO: Figure out a way to test expressions equality
        // [TestCase("word")]
        // [TestCase("fefwf352")]
        // public void SearchAds_ShouldCallAdsRepostoryWithCorrectExpression(string word)
        // {
        //     var mockedUnitOfWork = new Mock<IUnitOfWork>();
        //     var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
        //     var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
        //     var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
        //     Expression<Func<Advertisement, bool>> expression =x => x.Name.Contains(word);
        //     Expression<Func<Advertisement, bool>> actual = null;

        //     mockedAdsRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<Advertisement, bool>>>()))
        //         .Callback((Expression<Func<Advertisement, bool>> x) => actual = x);

        //     var service = new AdvertisementsService(
        //         mockedUnitOfWork.Object,
        //         mockedCategoriesRepo.Object,
        //         mockedCitiesRepo.Object,
        //         mockedAdsRepo.Object);

        //     service.SearchAds(word);

        //     Assert.AreEqual(expression.ToString(), actual.ToString());
        // }

        // [Test]
        // public void SearchAds_ShouldReturnTheSearchResult()
        // {
        //     var mockedUnitOfWork = new Mock<IUnitOfWork>();
        //     var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
        //     var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
        //     var mockedAdsRepo = new Mock<IGenericRepository<Advertisement>>();
        //     var expected = new List<Advertisement>()
        //     {
        //         new Mock<Advertisement>().Object,
        //         new Mock<Advertisement>().Object,
        //         new Mock<Advertisement>().Object
        //     };

        //     mockedAdsRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<Advertisement, bool>>>()))
        //         .Returns(expected);

        //     var service = new AdvertisementsService(
        //         mockedUnitOfWork.Object,
        //         mockedCategoriesRepo.Object,
        //         mockedCitiesRepo.Object,
        //         mockedAdsRepo.Object);

        //     var result = service.SearchAds("word");

        //     Assert.AreEqual(expected, result);
        // }
    }
}
