using System;
using WebFormsMvp;
using WebFormsMvp.Binder;

namespace CourseProject.Web.App_Start.Factories
{
    public class MvpPresenterFactory : IPresenterFactory
    {
        private readonly ICustomPresenterFactory factory;

        public MvpPresenterFactory(ICustomPresenterFactory factory)
        {
            this.factory = factory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            return this.factory.GetPresenter(presenterType, viewInstance);
        }

        public void Release(IPresenter presenter)
        {
            var disposable = presenter as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}