using System;
using System.Collections.Generic;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;
using CourseProject.Web.EventArguments.Contracts;
using CourseProject.Web.Views;

namespace CourseProject.Tests.Web.Presenters.Mocks
{
    public class MockedPersonalProfileView : IPersonalProfileView
    {
        private HashSet<string> gettingUserInvocationlist;
        
        public event EventHandler<IdEventArgs> RemovingSavedAd;
        private event EventHandler<IGetUserByIdEventArgs> gettingUser;

        public MockedPersonalProfileView()
        {
            this.gettingUserInvocationlist = new HashSet<string>();
        }

        public PersonalProfileModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public event EventHandler Load;

        public event EventHandler<IGetUserByIdEventArgs> GettingUser
        {
            add
            {
                this.gettingUser += value;
                this.gettingUserInvocationlist.Add(value.Method.Name);
            }

            remove
            {
                this.gettingUser -= value;
                this.gettingUserInvocationlist.Remove(value.Method.Name);
            }
        }
        
        public void InvokeGettingUser(object sender, GetUserByIdEventArgs e)
        {
            this.gettingUser?.Invoke(sender, e);
        }

        public bool IsSubscribedGettingUser(string methodName)
        {
            return this.gettingUserInvocationlist.Contains(methodName);
        }
    }
}