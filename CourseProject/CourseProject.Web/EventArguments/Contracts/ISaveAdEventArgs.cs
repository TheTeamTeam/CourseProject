using CourseProject.Models;

namespace CourseProject.Web.EventArguments.Contracts
{
    public interface ISaveAdEventArgs
    {
        Advertisement Ad { get; }
        string Id { get; }
    }
}