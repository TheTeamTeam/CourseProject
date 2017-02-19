using NUnit.Framework;
using CourseProject.Mvp.Account.Login;
using CourseProject.Mvp.Tests.Account.Login.LoginPresenterTests.Mocks;

namespace CourseProject.Mvp.Tests.Account.Login.LoginPresenterTests
{
    [TestFixture]
    public class Contructor_Should
    {
        [Test]
        public void AttachEventToViewLoggingIn()
        {
            var mockedView = new MockedLoginView();

            var presenter = new LoginPresenter(mockedView);

            Assert.IsTrue(mockedView.IsSubscribed("OnLoggingIn"));
        }
    }
}
