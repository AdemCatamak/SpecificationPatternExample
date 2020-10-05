using System;
using System.Linq.Expressions;
using SpecificationPatternExample.Specification.ExpressionSpecificationSection.Specifications;

namespace SpecificationPatternExample.Specification.ExpressionSpecificationSection.SpecificationOperations
{
    internal class ExpressionSpecificationOrOperator : IExpressionSpecificationOperator
    {
        public ExpressionSpecification<TModel> Combine<TModel>(ExpressionSpecification<TModel> left, ExpressionSpecification<TModel> right)
        {
            BinaryExpression body = Expression.OrElse(left.Expression.Body, right.Expression.Body);
            Expression<Func<TModel, bool>> lambda = Expression.Lambda<Func<TModel, bool>>(body, left.Expression.Parameters[0]);
            var dynamicExpressionSpecification = new DynamicExpressionSpecification<TModel>(Expression.Lambda<Func<TModel, bool>>(lambda));

            return dynamicExpressionSpecification;
        }
    }

    public static class ExpressionSpecificationOrOperatorExtension
    {
        public static ExpressionSpecification<T> Or<T>(this ExpressionSpecification<T> specificationLeft, ExpressionSpecification<T> specificationRight)
        {
            var specificationOrOperator = new ExpressionSpecificationOrOperator();
            ExpressionSpecification<T> expressionSpecification = specificationOrOperator.Combine(specificationLeft, specificationRight);
            return expressionSpecification;
        }
    }
}