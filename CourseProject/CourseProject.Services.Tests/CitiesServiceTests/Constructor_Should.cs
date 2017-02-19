using System;
using NUnit.Framework;

namespace CourseProject.Services.Tests.CitiesServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenCitiesRepositoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new CitiesService(null));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenCitiesRepositoryIsNull()
        {
            Assert.That(() => new CitiesService(null),
               Throws.ArgumentNullException.With.Message.Contains("Cities repository cannot be null."));
        }
    }
}
