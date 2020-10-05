using System.Linq;
using SpecificationPatternExample.Data.Models;
using SpecificationPatternExample.Specification.ExpressionSpecificationSection.Specifications;

namespace SpecificationPatternExample.Api.Specifications
{
    public class ShorterThanSpecification : ExpressionSpecification<UserModel>
    {
        public ShorterThanSpecification(int height) : base(u => u.Height < height)
        {
        }
    }
    
    public static class ShorterThanSpecificationExtension
    {
        public static bool ShorterThan(this UserModel userModel, int height)
        {
            var specification = new ShorterThanSpecification(height);
            bool result = specification.IsSatisfied(userModel);
            return result;
        }

        public static IQueryable<UserModel> ShorterThan(this IQueryable<UserModel> userModels, int height)
        {
            var specification = new ShorterThanSpecification(height);
            return userModels.Where(specification.Expression);
        }
    }
}