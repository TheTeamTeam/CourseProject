using System;
using CourseProject.Web.EventArguments.Contracts;

namespace CourseProject.Web.EventArguments
{
    public class SearchEventArgs : EventArgs, ISearchEventArgs
    {
        public SearchEventArgs(string searchWord, string orderBy,int categoryId, int cityId)
        {
            this.SearchWord = searchWord;
            this.OrderBy = orderBy;
            this.CategoryId = categoryId;
            this.CityId = cityId;
        }

        public string SearchWord { get; set; }

        public string OrderBy { get; set; }

        public int CategoryId { get; set; }

        public int CityId { get;  set; }
    }
}