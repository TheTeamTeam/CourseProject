namespace CourseProject.Mvp.EventArgsContracts
{
    public interface IAdDetailsEventArgs
    {
        int AdId { get; }

        string UserId { get; }
    }
}