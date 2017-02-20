using ImageResizer.Plugins;
using ImageResizer.Resizing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageResizer.Configuration;
using ImageResizer;

namespace CourseProject.Mvp.Tests.CreateAdvertisement.CreateAdvertisementPresenterTests.ImageResizerExtensions
{
    public class ImageBuilderMock : BuilderExtension, IPlugin
    {
        public IPlugin Install(Config c)
        {
            return new ImageBuilderMock();
        }

        public bool Uninstall(Config c)
        {
            return true;
        }

        protected override RequestedAction BuildJob(ImageJob job)
        {
            return new RequestedAction();
        }
    }
}
