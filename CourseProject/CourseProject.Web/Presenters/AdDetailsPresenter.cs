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
            this.View.BookAd += View_BookAd;
            this.View.SaveAd += View_SaveAd;
        }

        private void View_MyInit(object sender, AdDetailsEventArgs e)
        {
            this.View.Model.Advertisement = this.adsService.GetAdById(e.Id);
        }

        private void View_BookAd(object sender, BookAdEventArgs e)
        {
            if (!this.usersService.UserBookedAd(e.Id, e.Ad))
            {
                this.usersService.AddAdToUpcoming(e.Id, e.Ad);
                this.adsService.DecrementFreePlaces(e.Ad);
            }
            else
            {
                //TODO: already booked this ad
            }
        }

        private void View_SaveAd(object sender, BookAdEventArgs e)
        {
            if(!this.usersService.UserSavedAd(e.Id, e.Ad))
            {
                this.usersService.AddAdToSaved(e.Id, e.Ad);
            }
            else
            {
                //TODO: already saved this ad
            }
        }
    }
}