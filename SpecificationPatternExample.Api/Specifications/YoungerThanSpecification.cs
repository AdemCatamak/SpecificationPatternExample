using System.Collections.Generic;
using System.Linq;
using SpecificationPatternExample.Data.Models;
using SpecificationPatternExample.Specification.ExpressionSpecificationSection.Specifications;

namespace SpecificationPatternExample.Api.Specifications
{
    public class YoungerThanSpecification : ExpressionSpecification<UserModel>
    {
        public YoungerThanSpecification(int threshold) : base(u => u.Age < threshold)
        {
        }
    }

    public static class YoungerThanSpecificationExtension
    {
        public static bool YoungerThan(this UserModel userModel, int threshold)
        {
            var specification = new YoungerThanSpecification(threshold);
            bool result = specification.IsSatisfied(userModel);
            return result;
        }

        public static IEnumerable<UserModel> YoungerThan(this IEnumerable<UserModel> userModels, int threshold)
        {
            return userModels.Where(x => x.YoungerThan(threshold));
        }

        public static IQueryable<UserModel> YoungerThan(this IQueryable<UserModel> userModels, int threshold)
        {
            var specification = new YoungerThanSpecification(threshold);
            return userModels.Where(specification.Expression);
        }
    }
}