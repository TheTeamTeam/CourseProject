using System;
using CourseProject.Web.EventArguments.Contracts;

namespace CourseProject.Web.EventArguments
{
    public class SearchEventArgs : EventArgs, ISearchEventArgs
    {
        public SearchEventArgs(string searchWord)
        {
            this.SearchWord = searchWord;
        }

        public string SearchWord { get; set; }
    }
}