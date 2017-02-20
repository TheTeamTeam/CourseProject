using System;
using NUnit.Framework;
using Moq;
using CourseProject.Mvp.Home;

namespace CourseProject.Mvp.Tests.Home.HomePresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenAdvertisementsServiceIsNull()
        {
            var mockedView = new Mock<IHomeView>();

            Assert.Throws<ArgumentNullException>(() => new HomePresenter(mockedView.Object, null));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenAdvertisementsServiceIsNull()
        {
            var mockedView = new Mock<IHomeView>();


            Assert.That(() => new HomePresenter(mockedView.Object, null),
                    Throws.ArgumentNullException.With.Message.Contains("Advertisements service cannot be null."));
        }
    }
}
