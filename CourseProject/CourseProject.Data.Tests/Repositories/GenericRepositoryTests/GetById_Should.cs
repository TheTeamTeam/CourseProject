using System.Data.Entity;
using NUnit.Framework;
using Moq;
using CourseProject.Data.Tests.Repositories.GenericRepositoryTests.Mocks;
using CourseProject.Data.Repositories;

namespace CourseProject.Data.Tests.Repositories.GenericRepositoryTests
{
    [TestFixture]
    public class GetById_Should
    {
        [TestCase(2)]
        [TestCase("i3hj4o2urhi")]
        public void CallDbSetFindMethod(object id)
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.Setup(x => x.Find(It.IsAny<object>())).Verifiable();

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            repository.GetById(id);

            mockedSet.Verify(x => x.Find(It.IsAny<object>()), Times.Once);
        }

        [TestCase(2)]
        [TestCase("i3hj4o2urhi")]
        public void CallDbSetFindMethodWithCorrectParameter(object id)
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.Setup(x => x.Find(It.IsAny<object>())).Verifiable();

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            repository.GetById(id);

            mockedSet.Verify(x => x.Find(id), Times.Once);
        }

        [Test]
        public void ReturnTheCorrectResult()
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var mockedModel = new MockedModel();
            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.Setup(x => x.Find(It.IsAny<object>())).Returns(mockedModel);

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = repository.GetById("ghcy3654uygk");

            Assert.AreEqual(mockedModel, result);
        }
    }
}
