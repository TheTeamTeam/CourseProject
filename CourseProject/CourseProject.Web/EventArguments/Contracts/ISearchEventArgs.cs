namespace CourseProject.Web.EventArguments.Contracts
{
    public interface ISearchEventArgs
    {
        string SearchWord { get; set; }

        string OrderBy { get; set; }
    }
}