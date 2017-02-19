using System;
using NUnit.Framework;

namespace CourseProject.Services.Tests.CategoriesServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenCitiesRepositoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new CategoriesService(null));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenCitiesRepositoryIsNull()
        {
            Assert.That(() => new CategoriesService(null),
               Throws.ArgumentNullException.With.Message.Contains("Categories repository cannot be null."));
        }
    }
}
