using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using NUnit.Framework;
using Moq;
using CourseProject.Data;
using CourseProject.Data.Repositories;
using CourseProject.Tests.Data.Repositories.Mocks;

namespace CourseProject.Tests.Data.Repositories
{
    // TODO: Should it be tested with different type
    [TestFixture]
    public class GenericRepositoryTests
    {
        [Test]
        public void Constructor_ShouldCallContextSetMethod()
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            mockedContext.Setup(x => x.Set<MockedModel>()).Verifiable();

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            mockedContext.Verify(x => x.Set<MockedModel>(), Times.Once);
        }

        [Test]
        public void AllProperty_ShouldReturnDbSet()
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = repository.All;

            Assert.AreEqual(mockedSet.Object, result);
        }

        [TestCase(2)]
        [TestCase("i3hj4o2urhi")]
        public void GetById_ShouldCallDbSetFindMethod(object id)
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
        public void GetById_ShouldCallDbSetFindMethodWithCorrectParameter(object id)
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
        public void GetById_ShouldReturnTheCorrectResult()
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

        [Test]
        public void GetAll_ShouldReturnTheDbSetAsIEnumerable()
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
        public void GetAllWithFilter_ShouldReturnEmptyListWhenNoObjectsMatch()
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
        public void GetAllWithFilter_ShouldReturnCorrectListObjects()
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
        public void GetAllWithSorting_ShouldReturnSortedListObjects()
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
        public void GetAllWithFilterAndSorting_ShouldReturnSortedMatchingListObjects()
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
        public void GetAllWithSelect_ShouldReturnSelectValuesListObjects()
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
        public void GetAllWithFilterSortAndSelect_ShouldReturnCorrectListObjects()
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

        // [Test]
        // public void Select_ShouldReturnSelectValuesListObjects()
        // {
        //     var mockedContext = new Mock<IAdsHubDbContext>();
        //     var mockedSet = new Mock<IDbSet<MockedModel>>();
        //     var mockedMatch1 = new MockedModel();
        //     mockedMatch1.Name = "1 - first";
        //     var mockedMatch2 = new MockedModel();
        //     mockedMatch2.Name = "2 - second";
        //
        //     var data = new List<MockedModel>()
        //     {
        //         mockedMatch2,
        //         mockedMatch1
        //     }.AsQueryable();
        //
        //     mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
        //     mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
        //     mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
        //     mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
        //     mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        //
        //     var repository = new GenericRepository<MockedModel>(mockedContext.Object);
        //
        //     var result = repository.Select<string>(x => x.Name).ToList();
        //
        //     Assert.AreEqual(2, result.Count());
        //     Assert.AreEqual(result[0], mockedMatch2.Name);
        //     Assert.AreEqual(result[1], mockedMatch1.Name);
        // }

        // TODO: Maybe refactor repository or figure out how to test it
        // [Test]
        // public void Add_ShouldChangeEntityStateToAdded()
        // {
        //     var mockedContext = new Mock<IAdsHubDbContext>();
        //     var mockedSet = new Mock<IDbSet<MockedModel>>();
        //     var mockedModel = new MockedModel();          
        //     var mockedEntry = new Mock<DbEntityEntry<MockedModel>>();
        //     mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
        //     mockedContext.Setup(x => x.Entry(It.IsAny<MockedModel>())).Returns(mockedEntry.Object);
        //     // mockedEntry.SetupSet(x => x.State = It.IsAny<EntityState>()).Verifiable();
           
        //     var repository = new GenericRepository<MockedModel>(mockedContext.Object);

        //     // mockedEntry.Verify(x => x.State = EntityState.Added, Times.Once);
        // }
    }
}
