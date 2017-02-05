using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CourseProject.Web.Account.Views;
using CourseProject.Web.Account.Presenters;
using CourseProject.Tests.Web.Account.Presenters.Mocks;

namespace CourseProject.Tests.Web.Account.Presenters
{
    [TestFixture]
    public class LoginPresenterTests
    {
        [Test]
        public void Constructor_ShouldAttachEventToViewLoggingIn()
        {
            var mockedView = new MockedLoginView();

            var presenter = new LoginPresenter(mockedView);

            Assert.IsTrue(mockedView.IsSubscribed("View_LoggingIn"));
        }
    }
}
