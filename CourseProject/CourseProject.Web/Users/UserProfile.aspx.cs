﻿using System;
using Microsoft.AspNet.Identity;
using WebFormsMvp.Web;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;
using CourseProject.Web.Views;

namespace CourseProject.Web.Users
{
    public partial class UserProfile : MvpPage<UserProfileModel>, IUserProfileView
    {
        public event EventHandler<GetUserByUsernameEventArgs> GettingUser;
        public event EventHandler<RoleEventArgs> AddingRole;
        public event EventHandler<RoleEventArgs> RemovingRole;

        protected void Page_Load(object sender, EventArgs e)
        {
            var username = (string)this.Page.RouteData.Values["username"];

            // TODO: maybe remove checks
            if (username == null)
            {
                // TODO: redirect to not found
                this.Server.Transfer("~/ErrorPages/404.aspx");
            }

            if(username == this.User.Identity.GetUserName())
            {
                this.Response.Redirect("~/users/profile");
            }
            
            this.GettingUser?.Invoke(this, new GetUserByUsernameEventArgs(username, this.Context));

            if (this.Model.ProfileUser == null)
            {
                // TODO: redirect to not found
                this.Server.Transfer("~/ErrorPages/404.aspx");
            }

            // TODO: allow for all users and check for sellers

            // Only admins can view all users profiles. Regular users can view only profile of sellers
            if (!this.User.IsInRole("Admin") && !this.Model.IsSeller)
            {
                this.Server.Transfer("~/ErrorPages/401.aspx");
            }

            // Calling data bind here because otherwise the admin control does not receive the user id
            this.DataBind();
        }
    }
}