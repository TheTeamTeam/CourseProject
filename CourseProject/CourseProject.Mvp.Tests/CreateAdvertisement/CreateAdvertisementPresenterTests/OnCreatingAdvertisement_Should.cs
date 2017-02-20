using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NUnit.Framework;
using Moq;
using CourseProject.Mvp.CreateAdvertisement;
using CourseProject.Services.Contracts;
using CourseProject.Mvp.ImageResizing;
using CourseProject.Models;
using ImageResizer;
using CourseProject.Mvp.Tests.CreateAdvertisement.CreateAdvertisementPresenterTests.ImageResizerExtensions;

namespace CourseProject.Mvp.Tests.CreateAdvertisement.CreateAdvertisementPresenterTests
{
    [TestFixture]
    public class OnCreatingAdvertisement_Should
    {
        // call service
        // call service with correct param
        // call factory with correct param
        // call factory with correct param
        // call build
        // call build

        //[Test]
        //public void CallServiceCreateAdvertisement()
        //{
        //    var model = new CreateAdvertisementModel();
        //    var mockedView = new Mock<ICreateAdvertisementView>();
        //    var mockedAdsService = new Mock<IAdvertisementsService>();
        //    var mockedCitiesService = new Mock<ICitiesService>();
        //    var mockedCategoriesService = new Mock<ICategoriesService>();
        //    var mockedFactory = new Mock<IImageJobFactory>();
        //    var mockedFile = new Mock<HttpPostedFileBase>();

        //    mockedView.Setup(x => x.Model).Returns(model);
        //    mockedAdsService.Setup(x => x.CreateAdvertisement(It.IsAny<Advertisement>())).Verifiable();
        //    mockedFactory.Setup(x => x.CreateImageJob(It.IsAny<object>(), It.IsAny<object>(), It.IsAny<Instructions>())).Returns(new ImageJob());
            
        //    var presenter = new CreateAdvertisementPresenter(
        //      mockedView.Object,
        //      mockedAdsService.Object,
        //      mockedCitiesService.Object,
        //      mockedCategoriesService.Object,
        //      mockedFactory.Object);
        //    var eventArgs = new CreatingAdvertisementEventArgs(
        //       "name",
        //       "description",
        //       10,
        //       12.34m,
        //       new DateTime(2017, 2, 20),
        //       mockedFile.Object,
        //       1,
        //       1,
        //       "seller_id"
        //       );

        //    mockedView.Raise(x => x.CreatingAdvertisement += null, eventArgs);

        //    mockedAdsService.Verify(x => x.CreateAdvertisement(It.IsAny<Advertisement>()), Times.Once);
        //}
    }
}
