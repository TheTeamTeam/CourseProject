using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using CourseProject.Web.Models;
using CourseProject.Web.Views;
using CourseProject.Web.EventArguments;

namespace CourseProject.Web
{
    public partial class Search : MvpPage<SearchModel>, ISearchView
    {
        public event EventHandler Initializing;
        public event EventHandler<SearchEventArgs> Searching;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Initializing?.Invoke(this, new EventArgs());
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            var searchWord = this.SearchWord.Text;
            this.Searching?.Invoke(sender, new SearchEventArgs(searchWord));
        }
    }
}