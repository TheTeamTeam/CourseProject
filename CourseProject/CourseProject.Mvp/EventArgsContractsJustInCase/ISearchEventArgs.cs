namespace CourseProject.Mvp.EventArgsContracts
{
    public interface ISearchEventArgs
    {
        string SearchWord { get; set; }

        string OrderBy { get; set; }
    }
}