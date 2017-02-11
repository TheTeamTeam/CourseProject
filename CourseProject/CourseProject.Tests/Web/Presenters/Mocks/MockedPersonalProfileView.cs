using CourseProject.Web.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.Web.EventArguments;
using CourseProject.Web.Models;

namespace CourseProject.Tests.Web.Presenters.Mocks
{
    public class MockedPersonalProfileView : IPersonalProfileView
    {
        private event EventHandler<GetUserByIdEventArgs> gettingUser;

        private HashSet<string> gettingUserInvocationlist;

        public MockedPersonalProfileView()
        {
            this.gettingUserInvocationlist = new HashSet<string>();
        }

        public PersonalProfileModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public event EventHandler Load;
        
        public event EventHandler<GetUserByIdEventArgs> GettingUser
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

