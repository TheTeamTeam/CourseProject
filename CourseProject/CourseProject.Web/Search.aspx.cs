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
using CourseProject.Models;

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

                var cityId = this.Request.QueryString["cityId"] ?? "-1";
                this.CitiesDropDown.SelectedValue = cityId;

                var categoryId = this.Request.QueryString["categoryId"] ?? "-1";
                this.CategoriesDropDown.SelectedValue = categoryId;
            }
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            var searchWord = this.SearchWord.Text;
            this.Session["SearchWord"] = searchWord;

            this.PagerControl.SetPageProperties(0, this.PagerControl.MaximumRows, false);
        }

        protected void Options_Changed(object sender, EventArgs e)
        {
            this.PagerControl.SetPageProperties(0, this.PagerControl.MaximumRows, false);
        }

        public IQueryable<Advertisement> MainList_GetData()
        {
            var searchWord = (string)this.Session["SearchWord"] ?? "";

            var order = this.OrderProperties.SelectedValue;
            var cityId = int.Parse(this.CitiesDropDown.SelectedValue);
            var categoryId = int.Parse(this.CategoriesDropDown.SelectedValue);

            this.Searching?.Invoke(this, new SearchEventArgs(searchWord, order, categoryId, cityId));

            return this.Model.Advertisements;
        }
    }
}