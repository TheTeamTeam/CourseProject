﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CourseProject.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(object id);

        IQueryable<T> All { get; }

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression);

        IEnumerable<T> GetAll<T1>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression);

        IEnumerable<T2> GetAll<T1, T2>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T1>> sortExpression, Expression<Func<T, T2>> selectExpression);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression, string sortProperty, int skip, int take);
        
        IEnumerable<T1> Select<T1>(Expression<Func<T, T1>> selectExpression);

        int GetCount(Expression<Func<T, bool>> filterExpression);


        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
