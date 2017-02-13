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
            if (!this.Page.IsPostBack)
            {
                this.Initializing?.Invoke(this, new EventArgs());

                this.CitiesDropDown.DataSource = this.Model.Cities;
                // this.CitiesDropDown.DataBind();
                //this.CitiesDropDown.Items.Insert(0, new ListItem("All", "-1"));
                var cityId = this.Request.QueryString["cityId"] ?? "-1";
                this.CitiesDropDown.SelectedValue = cityId;

                this.CategoriesDropDown.DataSource = this.Model.Categories;
                // this.CategoriesDropDown.DataBind();
                //this.CategoriesDropDown.Items.Insert(0, new ListItem("All", "-1"));
                var categoryId = this.Request.QueryString["categoryId"] ?? "-1";
                this.CategoriesDropDown.SelectedValue = categoryId;

                var pageSize = int.Parse(this.PageSize.Text);
                this.Searching?.Invoke(sender, new SearchEventArgs(string.Empty, 1, pageSize, "Name",int.Parse(cityId), int.Parse(categoryId)));
                FillPager();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
        }


        //protected void MainList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        //{
        //    var searchWord = (string)this.Session["SearchWord"] ?? "";
        //    var order = this.OrderProperties.SelectedValue;
        //    int currentPage = (e.StartRowIndex / this.PagerControl.PageSize) + 1;

        //    this.Searching?.Invoke(sender, new SearchEventArgs(searchWord, currentPage + 1, this.PagerControl.PageSize, order));
        //}

        // TODO: Repeating code

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            var searchWord = this.SearchWord.Text;
            this.Session["SearchWord"] = searchWord;

            var order = this.OrderProperties.SelectedValue;
            var cityId = int.Parse(this.CitiesDropDown.SelectedValue);
            var categoryId = int.Parse(this.CategoriesDropDown.SelectedValue);
            var pageSize = int.Parse(this.PageSize.Text);

            this.Searching?.Invoke(this, new SearchEventArgs(searchWord, 1, pageSize, order, categoryId, cityId));

            FillPager();
        }

        protected void ChangePage_Click(object sender, EventArgs e)
        {
            var searchWord = (string)this.Session["SearchWord"] ?? "";

            var order = this.OrderProperties.SelectedValue;
            var cityId = int.Parse(this.CitiesDropDown.SelectedValue);
            var categoryId = int.Parse(this.CategoriesDropDown.SelectedValue);

            var pageSize = int.Parse(this.PageSize.Text);
            var page = int.Parse((sender as Button).Text);

            this.Searching?.Invoke(this, new SearchEventArgs(searchWord, page, pageSize, order, categoryId, cityId));
            this.FillPager();
        }

        protected void FillPager()
        {
            var pageSize = int.Parse(this.PageSize.Text);

            var number = (int)Math.Ceiling(this.Model.Count / (double)pageSize);

            this.PageControl.DataSource = new int[number];
            this.PageControl.DataBind();
        }

        protected void Options_Changed(object sender, EventArgs e)
        {
            var searchWord = (string)this.Session["SearchWord"] ?? "";

            var order = this.OrderProperties.SelectedValue;
            var cityId = int.Parse(this.CitiesDropDown.SelectedValue);
            var categoryId = int.Parse(this.CategoriesDropDown.SelectedValue);

            var pageSize = int.Parse(this.PageSize.Text);

            this.Searching?.Invoke(this, new SearchEventArgs(searchWord, 1, pageSize, order, categoryId, cityId));
            this.FillPager();
        }
    }
}