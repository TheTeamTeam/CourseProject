using ImageResizer;

namespace CourseProject.Mvp.ImageResizing
{
    public class ImageSaver : IImageSaver
    {
        public void SaveImage(ImageJob imageJob, bool createDir)
        {
            imageJob.CreateParentDirectory = createDir;
            imageJob.Build();
        }
    }
}
