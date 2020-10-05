using SpecificationPatternExample.Specification.ExpressionSpecificationSection.Specifications;

namespace SpecificationPatternExample.Specification.ExpressionSpecificationSection.SpecificationOperations
{
    public interface IExpressionSpecificationOperator
    {
        ExpressionSpecification<TModel> Combine<TModel>(ExpressionSpecification<TModel> left, ExpressionSpecification<TModel> right);
    }
}