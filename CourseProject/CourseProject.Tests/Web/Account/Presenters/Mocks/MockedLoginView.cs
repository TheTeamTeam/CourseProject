using CourseProject.Web.Account.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject.Web.Account.EventArguments;
using CourseProject.Web.Account.Models;

namespace CourseProject.Tests.Web.Account.Presenters.Mocks
{
    public class MockedLoginView : ILoginView
    {
        private event EventHandler<LoginEventArgs> logginIn;
        private HashSet<string> logginInInvocationList;

        public MockedLoginView()
        {
            this.logginInInvocationList = new HashSet<string>();
        }

        public event EventHandler Load;
        public event EventHandler<LoginEventArgs> LoggingIn
        {
            add
            {
                this.logginIn += value;
                this.logginInInvocationList.Add(value.Method.Name);
            }
            remove
            {
                this.logginIn -= value;
                this.logginInInvocationList.Remove(value.Method.Name);
            }
        }
                
        public LoginModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get; }

        public bool IsSubscribed(string methodName)
        {
            return this.logginInInvocationList.Contains(methodName);
        }
    }
}
