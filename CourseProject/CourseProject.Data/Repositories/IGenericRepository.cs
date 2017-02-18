using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CourseProject.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        // TODO: Remove if not used
        IQueryable<T> All { get; }

        T GetById(object id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression);

        IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression);

        IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression, Expression<Func<T, T2>> selectExpression);

        IQueryable<T> GetAllWithMultipleFilters(IEnumerable<Expression<Func<T, bool>>> filterExpressions, string orderProperty, bool ascending);

        IQueryable<T> IncludeMultiple(IQueryable<T> query, IEnumerable<Expression<Func<T, object>>> includes);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
