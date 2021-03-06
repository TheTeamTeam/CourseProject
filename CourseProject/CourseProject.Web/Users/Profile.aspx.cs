﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;
using CourseProject.Mvp.CommonEventArguments;
using CourseProject.Mvp.Users.PersonalProfile;

namespace CourseProject.Web.Users
{
    [PresenterBinding(typeof(PersonalProfilePresenter))]
    public partial class Profile : MvpPage<PersonalProfileModel>, IPersonalProfileView
    {
        public event EventHandler<GetUserByIdEventArgs> GettingUser;

        public event EventHandler<IdEventArgs> RemovingSavedAd;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = this.Page.User.Identity.GetUserId();
            var isSeller = this.Page.User.IsInRole("Seller") || this.Page.User.IsInRole("Admin");
            this.GettingUser?.Invoke(this, new GetUserByIdEventArgs(id, isSeller));
        }

        protected void RemoveFromSaved_Click(object sender, EventArgs e)
        {
            // TODO: Or hidden field or custom control
            var id = int.Parse((sender as Button).Attributes["data-id"]);
            this.RemovingSavedAd?.Invoke(this, new IdEventArgs(id));
        }
    }
}