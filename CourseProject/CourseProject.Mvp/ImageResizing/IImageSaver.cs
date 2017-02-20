using ImageResizer;

namespace CourseProject.Mvp.ImageResizing
{
    public interface IImageSaver
    {
        void SaveImage(ImageJob imageJob, bool createDir);
    }
}