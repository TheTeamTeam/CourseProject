using System;

namespace CourseProject.Web.EventArguments
{
    public class SearchEventArgs : EventArgs
    {
        public SearchEventArgs(string searchWord)
        {
            this.SearchWord = searchWord;
        }

        public string SearchWord { get; set; }
    }
}