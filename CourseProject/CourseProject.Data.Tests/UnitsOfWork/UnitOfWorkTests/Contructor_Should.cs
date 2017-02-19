using System;
using NUnit.Framework;
using CourseProject.Data.UnitsOfWork;

namespace CourseProject.Data.Tests.UnitsOfWork.UnitOfWorkTests
{
    [TestFixture]
    public class Contructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenDbContextIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitOfWork(null));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenDbContextIsNull()
        {
            Assert.That(() => new UnitOfWork(null),
                Throws.ArgumentNullException.With.Message.Contains("DbContext cannot be null."));
        }
    }
}
