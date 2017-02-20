using ImageResizer;

namespace CourseProject.Mvp.Factories
{
    public interface IImageJobFactory
    {
        ImageJob CreateImageJob(object source, object dest, Instructions instructions);
    }
}
