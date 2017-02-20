using System;
using NUnit.Framework;
using Moq;
using CourseProject.Mvp.CreateAdvertisement;
using CourseProject.Services.Contracts;
using CourseProject.Mvp.ImageResizing;

namespace CourseProject.Mvp.Tests.CreateAdvertisement.CreateAdvertisementPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenAdvertisementsServiceIsNull()
        {
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();

            Assert.Throws<ArgumentNullException>(() => new CreateAdvertisementPresenter(
                mockedView.Object,
                null,
                mockedCitiesService.Object,
                mockedCategoriesService.Object,
                mockedFactory.Object,
                mockedSaver.Object));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenAdvertisementsServiceIsNull()
        {
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();

            Assert.That(() => new CreateAdvertisementPresenter(
                mockedView.Object,
                null,
                mockedCitiesService.Object,
                mockedCategoriesService.Object,
                mockedFactory.Object,
                mockedSaver.Object),
               Throws.ArgumentNullException.With.Message.Contains("Advertisements service cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCitiesServiceIsNull()
        {
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();

            Assert.Throws<ArgumentNullException>(() => new CreateAdvertisementPresenter(
                mockedView.Object,
                mockedAdsService.Object,
                null,
                mockedCategoriesService.Object,
                mockedFactory.Object,
                mockedSaver.Object));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenCititesServiceIsNull()
        {
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();
            
            Assert.That(() => new CreateAdvertisementPresenter(
                mockedView.Object,
                mockedAdsService.Object,
                null,
                mockedCategoriesService.Object,
                mockedFactory.Object,
                mockedSaver.Object),
               Throws.ArgumentNullException.With.Message.Contains("Cities service cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCategoriesServiceIsNull()
        {
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();

            Assert.Throws<ArgumentNullException>(() => new CreateAdvertisementPresenter(
                mockedView.Object,
                mockedAdsService.Object,
                mockedCitiesService.Object,
                null,
                mockedFactory.Object,
                mockedSaver.Object));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenCategoriesServiceIsNull()
        {
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            var mockedSaver = new Mock<IImageSaver>();
            
            Assert.That(() => new CreateAdvertisementPresenter(
                mockedView.Object,
                mockedAdsService.Object,
                mockedCitiesService.Object,
                null,
                mockedFactory.Object,
                mockedSaver.Object),
               Throws.ArgumentNullException.With.Message.Contains("Categories service cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenImageJobFactoryIsNull()
        {
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedSaver = new Mock<IImageSaver>();

            Assert.Throws<ArgumentNullException>(() => new CreateAdvertisementPresenter(
                mockedView.Object,
                mockedAdsService.Object,
                mockedCitiesService.Object,
                mockedCategoriesService.Object,
                null,
                mockedSaver.Object));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenImageJobFactoryIsNull()
        {
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedSaver = new Mock<IImageSaver>();

            Assert.That(() => new CreateAdvertisementPresenter(
                mockedView.Object,
                mockedAdsService.Object,
                mockedCitiesService.Object,
                mockedCategoriesService.Object,
                null,
                mockedSaver.Object),
               Throws.ArgumentNullException.With.Message.Contains("Image job factory cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenImageSaverIsNull()
        {
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();
            
            Assert.Throws<ArgumentNullException>(() => new CreateAdvertisementPresenter(
                mockedView.Object,
                mockedAdsService.Object,
                mockedCitiesService.Object,
                mockedCategoriesService.Object,
                mockedFactory.Object,
                null));
        }

        [Test]
        public void ThrowExceptionWithCorrectMessage_WhenImageSaverIsNull()
        {
            var mockedView = new Mock<ICreateAdvertisementView>();
            var mockedAdsService = new Mock<IAdvertisementsService>();
            var mockedCitiesService = new Mock<ICitiesService>();
            var mockedCategoriesService = new Mock<ICategoriesService>();
            var mockedFactory = new Mock<IImageJobFactory>();

            Assert.That(() => new CreateAdvertisementPresenter(
                mockedView.Object,
                mockedAdsService.Object,
                mockedCitiesService.Object,
                mockedCategoriesService.Object,
                mockedFactory.Object,
                null),
               Throws.ArgumentNullException.With.Message.Contains("Image saver cannot be null."));
        }
    }
}
