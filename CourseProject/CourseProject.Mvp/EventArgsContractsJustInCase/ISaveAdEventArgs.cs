using CourseProject.Models;

namespace CourseProject.Mvp.EventArgsContracts
{
    public interface ISaveAdEventArgs
    {
        Advertisement Ad { get; }

        string Id { get; }
    }
}