using ImageResizer;

namespace CourseProject.Mvp.ImageResizing
{
    public interface IImageJobFactory
    {
        ImageJob CreateImageJob(object source, object dest, Instructions instructions);
    }
}
