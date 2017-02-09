﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebFormsMvp;
using WebFormsMvp.Web;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Presenters;
using CourseProject.Web.Models;
using CourseProject.Web.Views;


namespace CourseProject.Web.Users
{
    [PresenterBinding(typeof(PersonalProfilePresenter))]
    public partial class Profile : MvpPage<PersonalProfileModel>, IPersonalProfileView
    {
        public event EventHandler<GetUserByIdEventArgs> GettingUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = this.Page.User.Identity.GetUserId();
            this.GettingUser?.Invoke(this, new GetUserByIdEventArgs(id));
        }
    }
}