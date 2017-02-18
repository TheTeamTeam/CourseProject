using CourseProject.Models;

namespace CourseProject.Web.EventArguments.Contracts
{
    public interface IBookAdEventArgs
    {
        Advertisement Ad { get; }

        string Id { get; }
    }
}