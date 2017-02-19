using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Mvp.Tests.Account.Login.LoginPresenterTests
{
    class OtherTests
    {
        // Not working - extension methods
        // [Test]
        // public void OnLoggingIn_ShouldGetApplicationUserManagerFromEventArgsContext()
        // {
        //     var mockedView = new MockedLoginView();

        //     var mockedSignInManager = new Mock<ApplicationSignInManager>();
        //     var mockedEventArgs = new Mock<LoginEventArgs>();
        //     mockedEventArgs.Setup(x => x.Context.GetOwinContext().GetUserManager<ApplicationUserManager>()).Verifiable();
        //     mockedEventArgs.Setup(x => x.Context.GetOwinContext().GetUserManager<ApplicationSignInManager>())
        //         .Returns(mockedSignInManager.Object);

        //     var presenter = new LoginPresenter(mockedView);

        //     mockedView.InvokeLogginIn(mockedView, mockedEventArgs.Object);

        //     mockedEventArgs.Verify(x => x.Context.GetOwinContext().GetUserManager<ApplicationUserManager>(), Times.Once);
        //     mockedEventArgs.Verify(x => x.Context.GetOwinContext().GetUserManager<ApplicationSignInManager>(), Times.Once);
        // }

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
