using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;
using NUnit.Framework;
using CourseProject.Data.Repositories;
using CourseProject.Data.Tests.Repositories.GenericRepositoryTests.Mocks;

namespace CourseProject.Data.Tests.Repositories.GenericRepositoryTests
{
    [TestFixture]
    public class GetAll
    {
        [Test]
        public void ShouldReturnTheDbSetAsIEnumerable()
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var data = new List<MockedModel>()
            {
                new MockedModel(),
                new MockedModel(),
                new MockedModel()
            }.AsQueryable();

            // some magic
            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = repository.GetAll();

            Assert.AreEqual(data.ToList(), result);
        }

        [Test]
        public void WithFilter_ShouldReturnEmptyListWhenNoObjectsMatch()
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var data = new List<MockedModel>()
            {
                new MockedModel(),
                new MockedModel(),
                new MockedModel()
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = repository.GetAll(x => x.Name == "fqefwwef");

            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public void WithFilter_ShouldReturnCorrectListObjects()
        {
            var name = "TheName1234";
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var mockedMatch1 = new MockedModel();
            mockedMatch1.Name = name;
            var mockedMatch2 = new MockedModel();
            mockedMatch2.Name = name;

            var data = new List<MockedModel>()
            {
                mockedMatch1,
                mockedMatch2,
                new MockedModel(),
                new MockedModel(),
                new MockedModel()
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = repository.GetAll(x => x.Name == name).ToList();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(result[0], mockedMatch1);
            Assert.AreEqual(result[1], mockedMatch2);
        }

        [Test]
        public void WithSorting_ShouldReturnSortedListObjects()
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var mockedMatch1 = new MockedModel();
            mockedMatch1.Name = "1 - first";
            var mockedMatch2 = new MockedModel();
            mockedMatch2.Name = "2 - second";

            var data = new List<MockedModel>()
            {
                mockedMatch2,
                mockedMatch1
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = repository.GetAll(null, x => x.Name).ToList();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(result[0], mockedMatch1);
            Assert.AreEqual(result[1], mockedMatch2);
        }

        [Test]
        public void WithFilterAndSorting_ShouldReturnSortedMatchingListObjects()
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var mockedMatch1 = new MockedModel();
            mockedMatch1.Name = "1 - first";
            var mockedMatch2 = new MockedModel();
            mockedMatch2.Name = "2 - second";
            var mockedNotMatching = new MockedModel();
            mockedNotMatching.Name = "without dash";

            var data = new List<MockedModel>()
            {
                mockedMatch2,
                mockedNotMatching,
                mockedMatch1
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = repository.GetAll(x => x.Name.Contains("-"), x => x.Name).ToList();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(result[0], mockedMatch1);
            Assert.AreEqual(result[1], mockedMatch2);
        }

        [Test]
        public void WithSelect_ShouldReturnSelectValuesListObjects()
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var mockedMatch1 = new MockedModel();
            mockedMatch1.Name = "1 - first";
            var mockedMatch2 = new MockedModel();
            mockedMatch2.Name = "2 - second";

            var data = new List<MockedModel>()
            {
                mockedMatch2,
                mockedMatch1
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = repository.GetAll<MockedModel, string>(null, null, x => x.Name).ToList();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(result[0], mockedMatch2.Name);
            Assert.AreEqual(result[1], mockedMatch1.Name);
        }

        [Test]
        public void WithFilterSortAndSelect_ShouldReturnCorrectListObjects()
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var mockedMatch1 = new MockedModel();
            mockedMatch1.Name = "1 - first";
            var mockedMatch2 = new MockedModel();
            mockedMatch2.Name = "2 - second";
            var mockedMatch3 = new MockedModel();
            mockedMatch3.Name = "3 -third first";
            var mockedNotMatching = new MockedModel();
            mockedNotMatching.Name = "without dash";

            var data = new List<MockedModel>()
            {
                mockedMatch3,
                mockedMatch2,
                mockedNotMatching,
                mockedMatch1,
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = repository.GetAll(x => x.Name.Contains("-"), x => x.Name, x => x.Name).ToList();

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(result[0], mockedMatch1.Name);
            Assert.AreEqual(result[1], mockedMatch2.Name);
            Assert.AreEqual(result[2], mockedMatch3.Name);
        }
    }
}
