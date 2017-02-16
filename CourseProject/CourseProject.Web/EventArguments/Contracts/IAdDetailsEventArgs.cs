namespace CourseProject.Web.EventArguments.Contracts
{
    public interface IAdDetailsEventArgs
    {
        int AdId { get; }

        string UserId { get; }
    }
}