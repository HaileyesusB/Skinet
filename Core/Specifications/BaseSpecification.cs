using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy  { get; private set; }

        public Expression<Func<T, object>> OrderByDesending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPageingEnabled { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression) 
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> OrderByExpression)
        {
            OrderBy = OrderByExpression;
        }

        protected void AddOrderByDesending(Expression<Func<T, object>> OrderByDescendingExpression)
        {
            OrderByDesending = OrderByDescendingExpression;
        }

        protected void ApplyPaging(int skip , int taken) 
        {
            Skip = skip;
            Take = taken;
            IsPageingEnabled = true;
        }
    }
}
