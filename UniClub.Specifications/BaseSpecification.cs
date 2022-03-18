using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UniClub.Specifications.Interfaces;

namespace UniClub.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }

        private readonly List<Expression<Func<T, object>>> _includeCollection = new List<Expression<Func<T, object>>>();
        private readonly List<Expression<Func<T, bool>>> _filterCollection = new List<Expression<Func<T, bool>>>();
        private readonly List<string> _stringIncludeCollection = new List<string>();

        public List<Expression<Func<T, bool>>> FilterCondition { get => _filterCollection; }
        public string? OrderBy { get; private set; }
        public bool IsAscending { get; private set; }
        public bool IsPagination { get; set; } = true;
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 50;

        public List<Expression<Func<T, object>>> Includes => _includeCollection;
        public List<string> StringIncludes => _stringIncludeCollection;

        public Expression<Func<T, object>> GroupBy { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddInclude(string navigationPropertyPath)
        {
            StringIncludes.Add(navigationPropertyPath);
        }

        protected void ApplyOrderBy(string orderBy)
        {
            OrderBy = orderBy;
        }

        protected void ApplyOrder(bool isAscending)
        {
            IsAscending = isAscending;
        }

        protected void SetFilterCondition(Expression<Func<T, bool>> filterExpression)
        {
            FilterCondition.Add(filterExpression);
        }

        protected void ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }

        protected void NotApplyPagination()
        {
            IsPagination = false;
        }

        protected void ApplyPagination(int pageNumber, int pageSize)
        {
            Skip = (pageNumber - 1) * pageSize;
            Take = pageSize;
        }
    }
}
