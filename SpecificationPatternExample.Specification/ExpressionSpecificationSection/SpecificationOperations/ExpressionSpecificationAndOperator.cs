using System;
using System.Linq.Expressions;
using SpecificationPatternExample.Specification.ExpressionSpecificationSection.Specifications;

namespace SpecificationPatternExample.Specification.ExpressionSpecificationSection.SpecificationOperations
{
    internal class ExpressionSpecificationAndOperator : IExpressionSpecificationOperator
    {
        public ExpressionSpecification<TModel> Combine<TModel>(ExpressionSpecification<TModel> left, ExpressionSpecification<TModel> right)
        {
            BinaryExpression body = Expression.AndAlso(left.Expression.Body, right.Expression.Body);
            Expression<Func<TModel, bool>> lambda = Expression.Lambda<Func<TModel, bool>>(body, left.Expression.Parameters[0]);
            var dynamicExpressionSpecification = new DynamicExpressionSpecification<TModel>(Expression.Lambda<Func<TModel, bool>>(lambda));

            return dynamicExpressionSpecification;
        }
    }

    public static class ExpressionSpecificationAndOperatorExtension
    {
        public static ExpressionSpecification<T> And<T>(this ExpressionSpecification<T> specificationLeft, ExpressionSpecification<T> specificationRight)
        {
            var specificationAndOperator = new ExpressionSpecificationAndOperator();
            ExpressionSpecification<T> expressionSpecification = specificationAndOperator.Combine(specificationLeft, specificationRight);
            return expressionSpecification;
        }
    }
}