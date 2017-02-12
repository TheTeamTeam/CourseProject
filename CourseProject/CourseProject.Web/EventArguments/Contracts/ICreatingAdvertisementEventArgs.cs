using CourseProject.Models;

namespace CourseProject.Web.EventArguments.Contracts
{
    public interface ICreatingAdvertisementEventArgs
    {
        Advertisement Advertisement { get; }
    }
}