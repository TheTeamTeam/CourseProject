using CourseProject.Mvp.Search;
using CourseProject.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Mvp.Tests.Search.SearchPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenAdvertisementsServiceIsNull()
        {
            var mockedView = new Mock<ISearchView>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();

            Assert.Throws<ArgumentNullException>(() => new SearchPresenter(mockedView.Object, 
                                                                           null,
                                                                           mockedCitiesService.Object,
                                                                           mockedCategoriesService.Object));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenAdvertisementsServiceIsNull()
        {
            var mockedView = new Mock<ISearchView>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();

            Assert.That(() => new SearchPresenter(mockedView.Object,
                                                  null,
                                                  mockedCitiesService.Object,
                                                  mockedCategoriesService.Object),
                Throws.ArgumentNullException.With.Message.Contains("Advertisements service cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCitiesServiceIsNull()
        {
            var mockedView = new Mock<ISearchView>();
            var mockedAdvertisementsService = new Mock<IAdvertisementsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();

            Assert.Throws<ArgumentNullException>(() => new SearchPresenter(mockedView.Object,
                                                                           mockedAdvertisementsService.Object,
                                                                           null,
                                                                           mockedCategoriesService.Object));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenCitiesServiceIsNull()
        {
            var mockedView = new Mock<ISearchView>();
            var mockedAdvertisementsService = new Mock<IAdvertisementsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();

            Assert.That(() => new SearchPresenter(mockedView.Object,
                                                  mockedAdvertisementsService.Object,
                                                  null,
                                                  mockedCategoriesService.Object),
                Throws.ArgumentNullException.With.Message.Contains("Cities service cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCategoriesServiceIsNull()
        {
            var mockedView = new Mock<ISearchView>();
            var mockedAdvertisementsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();

            Assert.Throws<ArgumentNullException>(() => new SearchPresenter(mockedView.Object,
                                                                           mockedAdvertisementsService.Object,
                                                                           mockedCitiesService.Object,
                                                                           null));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenCategoriesServiceIsNull()
        {
            var mockedView = new Mock<ISearchView>();
            var mockedAdvertisementsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();

            Assert.That(() => new SearchPresenter(mockedView.Object,
                                                  mockedAdvertisementsService.Object,
                                                  mockedCitiesService.Object,
                                                  null),
                Throws.ArgumentNullException.With.Message.Contains("Categories service cannot be null."));
        }
    }
}
