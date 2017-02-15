namespace CourseProject.Web.EventArguments.Contracts
{
    public interface IGetUserByIdEventArgs
    {
        string Id { get; }

        bool IsSeller { get; }
    }
}