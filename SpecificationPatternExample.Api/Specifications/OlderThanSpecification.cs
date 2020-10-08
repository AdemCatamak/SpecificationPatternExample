using System.Collections.Generic;
using System.Linq;
using SpecificationPatternExample.Data.Models;
using SpecificationPatternExample.Specification.ExpressionSpecificationSection.Specifications;

namespace SpecificationPatternExample.Api.Specifications
{
    public class OlderThanSpecification : ExpressionSpecification<UserModel>
    {
        public OlderThanSpecification(int threshold) : base(u => u.Age > threshold)
        {
        }
    }

    public static class OlderThanSpecificationExtension
    {
        public static bool OlderThan(this UserModel userModel, int threshold)
        {
            var specification = new OlderThanSpecification(threshold);
            bool result = specification.IsSatisfied(userModel);
            return result;
        }

        public static IEnumerable<UserModel> OlderThan(this IEnumerable<UserModel> userModels, int threshold)
        {
            return userModels.Where(x => x.OlderThan(threshold));
        }

        public static IQueryable<UserModel> OlderThan(this IQueryable<UserModel> userModels, int threshold)
        {
            var specification = new OlderThanSpecification(threshold);
            return userModels.Where(specification.Expression);
        }
    }
}