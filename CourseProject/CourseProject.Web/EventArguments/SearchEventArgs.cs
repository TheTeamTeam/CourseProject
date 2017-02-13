using System;
using CourseProject.Web.EventArguments.Contracts;

namespace CourseProject.Web.EventArguments
{
    public class SearchEventArgs : EventArgs, ISearchEventArgs
    {
        public SearchEventArgs(string searchWord, int page, int pageSize, string orderBy)
        {
            this.SearchWord = searchWord;
            this.Page = page;
            this.PageSize = pageSize;
            this.OrderBy = orderBy;
        }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public string SearchWord { get; set; }

        public string OrderBy { get; set; }
    }
}