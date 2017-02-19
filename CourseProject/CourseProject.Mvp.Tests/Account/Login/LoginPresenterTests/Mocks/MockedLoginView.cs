using System;
using System.Collections.Generic;
using CourseProject.Mvp.Account.Login;

namespace CourseProject.Mvp.Tests.Account.Login.LoginPresenterTests.Mocks
{
    public class MockedLoginView : ILoginView
    {
        private HashSet<string> logginInInvocationList;

        private event EventHandler<LoginEventArgs> logginIn;

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

        public void InvokeLogginIn(object sender, LoginEventArgs e)
        {
            this.logginIn?.Invoke(sender, e);
        }
    }
}
