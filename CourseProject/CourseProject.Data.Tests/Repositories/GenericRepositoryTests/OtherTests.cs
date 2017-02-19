using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Data.Tests.Repositories.GenericRepositoryTests
{
    class OtherTests
    {
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
