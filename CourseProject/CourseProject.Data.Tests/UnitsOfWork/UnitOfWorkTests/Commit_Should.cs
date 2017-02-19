using Moq;
using NUnit.Framework;
using CourseProject.Data.UnitsOfWork;

namespace CourseProject.Data.Tests.UnitsOfWork.UnitOfWorkTests
{
    [TestFixture]
    public class Commit_Should
    {

        [Test]
        public void CallSaveChangesOnDbContext()
        {
            var mockedContext = new Mock<IAdsHubDbContext>();
            mockedContext.Setup(x => x.SaveChanges()).Verifiable();
            var unifOfWork = new UnitOfWork(mockedContext.Object);

            unifOfWork.Commit();

            mockedContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
