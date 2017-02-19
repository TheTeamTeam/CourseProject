using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CourseProject.Data.Repositories;
using CourseProject.Data.Tests.Repositories.GenericRepositoryTests.Mocks;

namespace CourseProject.Data.Tests.Repositories.GenericRepositoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CallContextSetMethod()
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            mockedContext.Setup(x => x.Set<MockedModel>()).Verifiable();

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            mockedContext.Verify(x => x.Set<MockedModel>(), Times.Once);
        }
    }
}
