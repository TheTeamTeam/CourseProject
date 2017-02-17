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
        public GenericRepository(IAdsHubDbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }


        // TODO: Make readonly field ??

        private IAdsHubDbContext Context { get; set; }

        private IDbSet<T> DbSet { get; set; }

        public IQueryable<T> All
        {
            get { return this.DbSet; }
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
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
            IQueryable<T> result = this.DbSet;

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
            IQueryable<T> result = this.DbSet;

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
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
        // TODO: should this stay
        //public IEnumerable<T1> Select<T1>(Expression<Func<T, T1>> selectExpression)
        //{
        //    return this.DbSet.Select(selectExpression).ToList();
        //}

        //public int GetCount(Expression<Func<T, bool>> filterExpression)
        //{
        //    IQueryable<T> result = this.DbSet;

        //    if(filterExpression != null)
        //    {
        //        result = result.Where(filterExpression);
        //    }

        //    return result.Count();
        //}

        public void Add(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            return entry;
        }
    }
}
