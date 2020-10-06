using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpecificationPatternExample.Data.Models;
using SpecificationPatternExample.Specification.ExpressionSpecificationSection.Specifications;

namespace SpecificationPatternExample.Data.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<UserModel> GetUsers(ExpressionSpecification<UserModel> expressionSpecification);
    }

    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<UserModel> GetUsers(ExpressionSpecification<UserModel> expressionSpecification)
        {
            var users = _dataContext.UserModels
                                    .Where(expressionSpecification.Expression)
                                    .TagWith("User Repository Fetch User according to Specification")
                                    .ToList()
                ;

            return users;
        }
    }
}