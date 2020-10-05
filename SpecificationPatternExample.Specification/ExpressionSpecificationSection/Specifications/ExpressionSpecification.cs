using System;
using System.Linq.Expressions;

namespace SpecificationPatternExample.Specification.ExpressionSpecificationSection.Specifications
{
    public abstract class ExpressionSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Expression { get; }

        private Func<T, bool> _expressionFunc;
        private Func<T, bool> ExpressionFunc => _expressionFunc ?? (_expressionFunc = Expression.Compile());

        protected ExpressionSpecification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public bool IsSatisfied(T obj)
        {
            bool result = ExpressionFunc(obj);
            return result;
        }
    }
}