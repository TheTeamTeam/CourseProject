namespace CourseProject.Web.EventArguments.Contracts
{
    public interface ISearchEventArgs
    {
        string SearchWord { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }

        string OrderBy { get; set; }
    }
}