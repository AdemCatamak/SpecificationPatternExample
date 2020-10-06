using System.Collections.Generic;
using System.Linq;
using SpecificationPatternExample.Data.Models;
using SpecificationPatternExample.Specification.ExpressionSpecificationSection.Specifications;

namespace SpecificationPatternExample.Api.Specifications
{
    public class OlderThanSpecification : ExpressionSpecification<UserModel>
    {
        public OlderThanSpecification(int age) : base(u => u.Age > age)
        {
        }
    }

    public static class OlderThanSpecificationExtension
    {
        public static bool OlderThan(this UserModel userModel, int age)
        {
            var specification = new OlderThanSpecification(age);
            bool result = specification.IsSatisfied(userModel);
            return result;
        }

        public static IEnumerable<UserModel> OlderThan(this IEnumerable<UserModel> userModels, int age)
        {
            return userModels.Where(x => x.OlderThan(age));
        }

        public static IQueryable<UserModel> OlderThan(this IQueryable<UserModel> userModels, int age)
        {
            var specification = new OlderThanSpecification(age);
            return userModels.Where(specification.Expression);
        }
    }
}