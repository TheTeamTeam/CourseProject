using CourseProject.Mvp.AdDetails;
using CourseProject.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Mvp.Tests.AdDetails.AdDetailsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenAdvertisementsServiceIsNull()
        {
            var mockedView = new Mock<IAdDetailsView>();
            var mockedUsersService = new Mock<IUsersService>();

            Assert.Throws<ArgumentNullException>(() => new AdDetailsPresenter(mockedView.Object,
                                                                              null,
                                                                              mockedUsersService.Object));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenAdvertisementsServiceIsNull()
        {
            var mockedView = new Mock<IAdDetailsView>();
            var mockedUsersService = new Mock<IUsersService>();

            Assert.That(() => new AdDetailsPresenter(mockedView.Object, null, mockedUsersService.Object),
                    Throws.ArgumentNullException.With.Message.Contains("Advertisements service cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUsersServiceIsNull()
        {
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();

            Assert.Throws<ArgumentNullException>(() => new AdDetailsPresenter(mockedView.Object,                                                                            
                                                                              mockedAdvertisementService.Object,
                                                                              null));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenUsersServiceIsNull()
        {
            var mockedView = new Mock<IAdDetailsView>();
            var mockedAdvertisementService = new Mock<IAdvertisementsService>();

            Assert.That(() => new AdDetailsPresenter(mockedView.Object, mockedAdvertisementService.Object, null),
                    Throws.ArgumentNullException.With.Message.Contains("Users service cannot be null."));
        }
    }
}
