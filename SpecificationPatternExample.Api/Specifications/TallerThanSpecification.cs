using System.Linq;
using SpecificationPatternExample.Data.Models;
using SpecificationPatternExample.Specification.ExpressionSpecificationSection.Specifications;

namespace SpecificationPatternExample.Api.Specifications
{
    public class TallerThanSpecification : ExpressionSpecification<UserModel>
    {
        public TallerThanSpecification(int height) : base(u => u.Height > height)
        {
        }
    }

    public static class TallerThanSpecificationExtension
    {
        public static bool TallerThan(this UserModel userModel, int height)
        {
            var specification = new TallerThanSpecification(height);
            bool result = specification.IsSatisfied(userModel);
            return result;
        }

        public static IQueryable<UserModel> TallerThan(this IQueryable<UserModel> userModels, int height)
        {
            var specification = new TallerThanSpecification(height);
            return userModels.Where(specification.Expression);
        }
    }
}