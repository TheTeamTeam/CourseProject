namespace CourseProject.Mvp.EventArgsContracts
{
    public interface IGetUserByIdEventArgs
    {
        string Id { get; }

        bool IsSeller { get; }
    }
}