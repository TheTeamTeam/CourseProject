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

namespace CourseProject.Services.Tests.CategoriesServiceTests
{
    [TestFixture]
    public class GetCategories_Should
    {
        [Test]
        public void CallCategoriesRepositoryMethod()
        {
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();

            mockedCategoriesRepo.Setup(x => x.GetAll()).Verifiable();

            var service = new CategoriesService(mockedCategoriesRepo.Object);

            service.GetCategories();

            mockedCategoriesRepo.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void ReturnTheResultFromTheRepositoryMethod()
        {
            var mockedCategoriesRepo = new Mock<IGenericRepository<Category>>();
            var expected = new List<Category>()
             {
                 new Mock<Category>().Object,
                 new Mock<Category>().Object,
                 new Mock<Category>().Object
             };

            mockedCategoriesRepo.Setup(x => x.GetAll()).Returns(expected);

            var service = new CategoriesService(mockedCategoriesRepo.Object);

            var result = service.GetCategories();

            Assert.AreEqual(expected, result);
        }
    }
}
