using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using System.Data.Entity;
using CourseProject.Data.Tests.Repositories.GenericRepositoryTests.Mocks;
using CourseProject.Data.Repositories;
using System.Linq.Expressions;

namespace CourseProject.Data.Tests.Repositories.GenericRepositoryTests
{
    [TestFixture]
    public class GetAllWithMultipleFilters_Should
    {
        [Test]
        public void WithFiltersReturn_CorrectListObjects()
        {
            var name = "TheName1234";
            var id = 17;
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var mockedMatch = new MockedModel();
            mockedMatch.Name = name;
            mockedMatch.Id = id;
            var mockedMatchName = new MockedModel();
            mockedMatchName.Name = name;
            var mockedMatchId = new MockedModel();
            mockedMatchId.Id = id;

            var data = new List<MockedModel>()
            {
                mockedMatchName,
                mockedMatchId,
                mockedMatch
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            var filters = new List<Expression<Func<MockedModel, bool>>>()
            {
                x => x.Name == name,
                x => x.Id == id
            };
            var result = repository.GetAllWithMultipleFilters(filters, null, true).ToList();

            var expected = new List<MockedModel> { mockedMatch };
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void WithOrder_ReturnOrderedListOfObjects()
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var mocked1 = new MockedModel();
            var mocked2 = new MockedModel();
            var mocked3 = new MockedModel();
            mocked1.Name = "aaa";
            mocked2.Name = "bbb";
            mocked3.Name = "ccc";

            var data = new List<MockedModel>()
            {
                mocked3,
                mocked2,
                mocked1
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = repository.GetAllWithMultipleFilters(null, "Name", true).ToList();

            CollectionAssert.AreEqual(data.OrderBy(x => x.Name), result);
        }

        [Test]
        public void WithOrderInDescending_ReturnOrderedListOfObjects()
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var mocked1 = new MockedModel();
            var mocked2 = new MockedModel();
            var mocked3 = new MockedModel();
            mocked1.Name = "aaa";
            mocked2.Name = "bbb";
            mocked3.Name = "ccc";

            // ordered ascending
            var data = new List<MockedModel>()
            {
                mocked1,
                mocked2,
                mocked3
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = repository.GetAllWithMultipleFilters(null, "Name", false).ToList();

            CollectionAssert.AreEqual(data.OrderByDescending(x => x.Name), result);
        }
        
        [Test]
        public void WithFiltersAndOrder_ReturnCorrectListObjects()
        {
            var id = 17;
            var mockedContext = new Mock<IAdsHubDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var mockedMatch1 = new MockedModel();
            var mockedMatch2 = new MockedModel();
            var mocked3 = new MockedModel();
            mockedMatch1.Name = "aaa";
            mockedMatch2.Name = "bbb";
            mocked3.Name = "ccc";
            mockedMatch1.Id = id;
            mockedMatch2.Id = id;

            var data = new List<MockedModel>()
            {
                mocked3,
                mockedMatch2,
                mockedMatch1
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            var filters = new List<Expression<Func<MockedModel, bool>>>()
            {
                x => x.Id == id
            };
            var result = repository.GetAllWithMultipleFilters(filters, "Name", true).ToList();

            var expected = data.Where(x => x.Id == id).OrderBy(x => x.Name);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
