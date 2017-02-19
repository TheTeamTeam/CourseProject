using System.Data.Entity;
using NUnit.Framework;
using Moq;
using CourseProject.Data.Repositories;
using CourseProject.Data.Tests.Repositories.GenericRepositoryTests.Mocks;

namespace CourseProject.Data.Tests.Repositories.GenericRepositoryTests
{
    [TestFixture]
    public class AllProperty_Should
    {
        [Test]
        public void ReturnDbSet()
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = repository.All;

            Assert.AreEqual(mockedSet.Object, result);
        }
    }
}
