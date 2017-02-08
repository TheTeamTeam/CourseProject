using CourseProject.Web.Models;
using CourseProject.Web.Presenters;
using CourseProject.Web.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using CourseProject.Web.EventArguments;
using CourseProject.Models;

namespace CourseProject.Web
{
    [PresenterBinding(typeof(AdDetailsPresenter))]
    public partial class AdDetails : MvpPage<AdDetailsModel>, IAdDetailsView
    {
        public event EventHandler<AdDetailsEventArgs> MyInit;

        public Advertisement Ad { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string idString = this.Request.QueryString["id"];
            int id = idString != null ? int.Parse(idString) : 1;

            this.MyInit?.Invoke(sender, new AdDetailsEventArgs(id));

            // TODO: Bind directly ro the model ??
            this.Ad = this.Model.Advertisement;

            Page.DataBind();
        }
    }
}