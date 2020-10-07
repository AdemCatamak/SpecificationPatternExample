using System.Collections.Generic;
using System.Linq;
using SpecificationPatternExample.Data.Models;
using SpecificationPatternExample.Specification.ExpressionSpecificationSection.Specifications;

namespace SpecificationPatternExample.Api.Specifications
{
    public class ShorterThanSpecification : ExpressionSpecification<UserModel>
    {
        public ShorterThanSpecification(int threshold) : base(u => u.Height < threshold)
        {
        }
    }

    public static class ShorterThanSpecificationExtension
    {
        public static bool ShorterThan(this UserModel userModel, int threshold)
        {
            var specification = new ShorterThanSpecification(threshold);
            bool result = specification.IsSatisfied(userModel);
            return result;
        }

        public static IEnumerable<UserModel> ShorterThan(this IEnumerable<UserModel> userModels, int threshold)
        {
            return userModels.Where(x => x.ShorterThan(threshold));
        }

        public static IQueryable<UserModel> ShorterThan(this IQueryable<UserModel> userModels, int threshold)
        {
            var specification = new ShorterThanSpecification(threshold);
            return userModels.Where(specification.Expression);
        }
    }
}