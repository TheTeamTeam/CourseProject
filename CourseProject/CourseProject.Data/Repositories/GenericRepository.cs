using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;

namespace CourseProject.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IAdsHubDbContext context;
        private readonly IDbSet<T> dbSet;

        public GenericRepository(IAdsHubDbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }

        public IQueryable<T> All
        {
            get { return this.dbSet; }
        }

        public T GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.GetAll(null);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression)
        {
            return this.GetAll<object>(filterExpression, null);
        }

        public IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression)
        {
            return this.GetAll<T1, T>(filterExpression, sortExpression, null);
        }

        public IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression, Expression<Func<T, T2>> selectExpression)
        {
            IQueryable<T> result = this.dbSet;

            if (filterExpression != null)
            {
                result = result.Where(filterExpression);
            }

            if (sortExpression != null)
            {
                result = result.OrderBy(sortExpression);
            }

            if (selectExpression != null)
            {
                return result.Select(selectExpression).ToList();
            }
            else
            {
                return result.OfType<T2>().ToList();
            }
        }

        public IQueryable<T> GetAllWithMultipleFilters(IEnumerable<Expression<Func<T, bool>>> filterExpressions, string orderProperty, bool ascending)
        {
            IQueryable<T> result = this.dbSet;

            if (filterExpressions != null)
            {
                foreach (var filterExpr in filterExpressions)
                {
                    result = result.Where(filterExpr);
                }
            }

            if (orderProperty != null)
            {
                if (ascending)
                {
                    result = result.OrderBy(orderProperty);
                }
                else
                {
                    result = result.OrderBy(orderProperty + " descending");
                }
            }

            return result;
        }

        // TODO: Should it be combined with other method
        public IQueryable<T> IncludeMultiple(IQueryable<T> query, IEnumerable<Expression<Func<T, object>>> includes)
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }

        public void Add(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            return entry;
        }
    }
}
