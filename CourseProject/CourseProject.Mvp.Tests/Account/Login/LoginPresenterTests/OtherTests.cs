using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CourseProject.Mvp.Account.Login;
using System.Web;

namespace CourseProject.Mvp.Tests.Account.Login.LoginPresenterTests
{
    [TestFixture]
    public class OtherTests
    {
        //[Test]
        //public void OnLoggingIn_ShouldGetApplicationUserManagerFromEventArgsContext()
        //{
        //    var model = new LoginModel();
        //    var mockedView = new Mock<ILoginView>();
        //    mockedView.Setup(x => x.Model).Returns(model);

        //    var presenter = new LoginPresenter(mockedView.Object);
            
        //    mockedView.Raise(x => x.LoggingIn += null, new LoginEventArgs(new HttpContext(), "username", "234456pass", true, false));

        //    Assert.IsNotNull(model.SignInStatus);
        //}

        // [Test]
        // public void OnLoggingIn_ShouldCallPasswordSignInOnTheSignInManager()
        // {
        //     var mockedView = new MockedLoginView();

        //     var mockedSignInManager = new Mock<ApplicationSignInManager>();
        //     mockedSignInManager.Setup(x => x.PasswordSignIn(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>())).Verifiable();
        //     var mockedEventArgs = new Mock<LoginEventArgs>();
        //     mockedEventArgs.Setup(x => x.Context.GetOwinContext().GetUserManager<ApplicationUserManager>()).Verifiable();
        //     mockedEventArgs.Setup(x => x.Context.GetOwinContext().GetUserManager<ApplicationSignInManager>())
        //         .Returns(mockedSignInManager.Object);

        //     var presenter = new LoginPresenter(mockedView);

        //     mockedView.InvokeLogginIn(mockedView, mockedEventArgs.Object);

        //     mockedSignInManager.Verify();
        // }
    }
}
