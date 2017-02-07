using CourseProject.Services.Contracts;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace CourseProject.Web.Presenters
{
    public class AdDetailsPresenter : Presenter<IAdDetailsView>
    {
        private readonly IAdvertisementsService adsService;

        public AdDetailsPresenter(IAdDetailsView view, IAdvertisementsService adsService)
            : base(view)
        {
            this.adsService = adsService;

            this.View.MyInit += this.View_MyInit;
        }

        private void View_MyInit(object sender, AdDetailsEventArgs e)
        {
            this.View.Model.Advertisement = this.adsService.GetAdById(e.Id);
        }
    }
}