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
        private readonly IUsersService usersService;

        public AdDetailsPresenter(IAdDetailsView view, 
                                  IAdvertisementsService adsService,
                                  IUsersService usersService)
            : base(view)
        {
            this.adsService = adsService;
            this.usersService = usersService;

            this.View.MyInit += this.View_MyInit;
            this.View.Book += View_Book;
        }

        private void View_MyInit(object sender, AdDetailsEventArgs e)
        {
            this.View.Model.Advertisement = this.adsService.GetAdById(e.Id);
        }

        private void View_Book(object sender, BookAdEventArgs e)
        {
            this.usersService.AddAdToUpcoming(e.Id, e.Ad);
        }
    }
}