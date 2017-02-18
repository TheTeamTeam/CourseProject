using CourseProject.Models;

namespace CourseProject.Mvp.EventArgsContracts
{
    public interface IBookAdEventArgs
    {
        Advertisement Ad { get; }

        string Id { get; }
    }
}