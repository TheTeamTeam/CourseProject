using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CourseProject.Data;
using CourseProject.Data.UnitsOfWork;

namespace CourseProject.Tests.Data.UnitsOfWork
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenDbContextIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitOfWork(null));
        }

        [Test]
        public void Constructor_ShouldThrowExceptionWithCorrectMessage_WhenDbContextIsNull()
        {
            Assert.That(()=> new UnitOfWork(null), 
                Throws.ArgumentNullException.With.Message.Contains("DbContext cannot be null."));
        }

        [Test]
        public void Commit_ShouldCallSaveChangesOnDbContext()
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            mockedContext.Setup(x => x.SaveChanges()).Verifiable();
            var unifOfWork = new UnitOfWork(mockedContext.Object);

            unifOfWork.Commit();

            mockedContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        // TODO: Test dispose
    }
}
