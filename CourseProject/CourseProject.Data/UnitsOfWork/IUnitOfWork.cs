using System;

namespace CourseProject.Data.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}