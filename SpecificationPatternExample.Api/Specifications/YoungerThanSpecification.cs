using System.Collections.Generic;
using System.Linq;
using SpecificationPatternExample.Data.Models;
using SpecificationPatternExample.Specification.ExpressionSpecificationSection.Specifications;

namespace SpecificationPatternExample.Api.Specifications
{
    public class YoungerThanSpecification : ExpressionSpecification<UserModel>
    {
        public YoungerThanSpecification(int age) : base(u => u.Age < age)
        {
        }
    }

    public static class YoungerThanSpecificationExtension
    {
        public static bool YoungerThan(this UserModel userModel, int age)
        {
            var specification = new YoungerThanSpecification(age);
            bool result = specification.IsSatisfied(userModel);
            return result;
        }

        public static IEnumerable<UserModel> YoungerThan(this IEnumerable<UserModel> userModels, int age)
        {
            return userModels.Where(x => x.YoungerThan(age));
        }

        public static IQueryable<UserModel> YoungerThan(this IQueryable<UserModel> userModels, int age)
        {
            var specification = new YoungerThanSpecification(age);
            return userModels.Where(specification.Expression);
        }
    }
}