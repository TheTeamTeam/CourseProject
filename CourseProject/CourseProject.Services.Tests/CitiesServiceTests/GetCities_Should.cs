using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CourseProject.Data.Repositories;
using CourseProject.Models;

namespace CourseProject.Services.Tests.CitiesServiceTests
{
    [TestFixture]
    public class GetCities_Should
    {
        [Test]
        public void CallCitiesRepositoryMethod()
        {
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            mockedCitiesRepo.Setup(x => x.GetAll()).Verifiable();

            var service = new CitiesService(mockedCitiesRepo.Object);

            service.GetCities();

            mockedCitiesRepo.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void ReturnTheResultFromTheRepositoryMethod()
        {
            var mockedCitiesRepo = new Mock<IGenericRepository<City>>();
            var expected = new List<City>()
             {
                 new Mock<City>().Object,
                 new Mock<City>().Object,
                 new Mock<City>().Object
             };

            mockedCitiesRepo.Setup(x => x.GetAll()).Returns(expected);

            var service = new CitiesService(mockedCitiesRepo.Object);

            var result = service.GetCities();

            Assert.AreEqual(expected, result);
        }
    }
}
