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
using CourseProject.Data;
using System.Data.Entity.Infrastructure;


namespace CourseProject.Web
{
    public partial class Search : MvpPage<SearchModel>, ISearchView
    {
        public event EventHandler Initializing;
        public event EventHandler<SearchEventArgs> Searching;

        protected void Page_Load(object sender, EventArgs e)
        {
            var pageSize = int.Parse(this.PageSize.Text);
            this.Searching?.Invoke(sender, new SearchEventArgs("", 1, pageSize, "Name"));
            FillPager();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            var searchWord = this.SearchWord.Text;
            this.Session["SearchWord"] = searchWord;

            var order = this.OrderProperties.SelectedValue;
            var pageSize = int.Parse(this.PageSize.Text);

            this.Searching?.Invoke(this, new SearchEventArgs(searchWord,1, pageSize, order));

            FillPager();
        }

        //protected void MainList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        //{
        //    var searchWord = (string)this.Session["SearchWord"] ?? "";
        //    var order = this.OrderProperties.SelectedValue;
        //    int currentPage = (e.StartRowIndex / this.PagerControl.PageSize) + 1;

        //    this.Searching?.Invoke(sender, new SearchEventArgs(searchWord, currentPage + 1, this.PagerControl.PageSize, order));
        //}

        protected void ChangePage_Click(object sender, EventArgs e)
        {
            var searchWord = (string)this.Session["SearchWord"] ?? "";

            var order = this.OrderProperties.SelectedValue;
            var pageSize = int.Parse(this.PageSize.Text);
            var page = int.Parse((sender as Button).Text);

            this.Searching?.Invoke(this, new SearchEventArgs(searchWord, page, pageSize, order));
            this.FillPager();
        }

        protected void FillPager()
        {
            var pageSize = int.Parse(this.PageSize.Text);

            var number = (int)Math.Ceiling(this.Model.Count / (double)pageSize);

            this.PageControl.DataSource = new int[number];
            this.PageControl.DataBind();
        }
    }
}