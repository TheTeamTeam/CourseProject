using System;

namespace CourseProject.Data.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAdsHubDbContext dbContext;

        public UnitOfWork(IAdsHubDbContext dbContext)
        {
            if(dbContext == null)
            {
                throw new ArgumentNullException("DbContext cannot be null.");
            }

            this.dbContext = dbContext;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        // TODO: Deicde whether to leave the empty method
        public void Dispose()
        {
        }
    }
}
