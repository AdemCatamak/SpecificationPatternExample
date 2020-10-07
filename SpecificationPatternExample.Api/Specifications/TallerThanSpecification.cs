using System.Collections.Generic;
using System.Linq;
using SpecificationPatternExample.Data.Models;
using SpecificationPatternExample.Specification.ExpressionSpecificationSection.Specifications;

namespace SpecificationPatternExample.Api.Specifications
{
    public class TallerThanSpecification : ExpressionSpecification<UserModel>
    {
        public TallerThanSpecification(int threshold) : base(u => u.Height > threshold)
        {
        }
    }

    public static class TallerThanSpecificationExtension
    {
        public static bool TallerThan(this UserModel userModel, int threshold)
        {
            var specification = new TallerThanSpecification(threshold);
            bool result = specification.IsSatisfied(userModel);
            return result;
        }

        public static IEnumerable<UserModel> TallerThan(this IEnumerable<UserModel> userModels, int threshold)
        {
            return userModels.Where(x => x.TallerThan(threshold));
        }

        public static IQueryable<UserModel> TallerThan(this IQueryable<UserModel> userModels, int threshold)
        {
            var specification = new TallerThanSpecification(threshold);
            return userModels.Where(specification.Expression);
        }
    }
}