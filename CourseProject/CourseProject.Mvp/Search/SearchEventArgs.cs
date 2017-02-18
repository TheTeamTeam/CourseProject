using System;

namespace CourseProject.Mvp.Search
{
    public class SearchEventArgs : EventArgs
    {
        public SearchEventArgs(string searchWord, string orderBy, int categoryId, int cityId)
        {
            this.SearchWord = searchWord;
            this.OrderBy = orderBy;
            this.CategoryId = categoryId;
            this.CityId = cityId;
        }

        public string SearchWord { get; set; }

        public string OrderBy { get; set; }

        public int CategoryId { get; set; }

        public int CityId { get; set; }
    }
}