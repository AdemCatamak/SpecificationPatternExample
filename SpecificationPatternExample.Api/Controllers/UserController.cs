using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpecificationPatternExample.Api.Specifications;
using SpecificationPatternExample.Data;
using SpecificationPatternExample.Data.Models;
using SpecificationPatternExample.Data.Repositories;
using SpecificationPatternExample.Specification.ExpressionSpecificationSection.SpecificationOperations;
using SpecificationPatternExample.Specification.ExpressionSpecificationSection.Specifications;

namespace SpecificationPatternExample.Api.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IUserRepository _userRepository;

        public UserController(DataContext dataContext, IUserRepository userRepository)
        {
            _dataContext = dataContext;
            _userRepository = userRepository;
        }

        [HttpGet("query-extension/users")]
        public async Task<IActionResult> GetUsersWithExtensions([FromQuery] int? shorterThan, [FromQuery] int? tallerThan,
                                                                [FromQuery] int? olderThan, [FromQuery] int? youngerThan)
        {
            IQueryable<UserModel> userModels = _dataContext.UserModels.AsQueryable();

            if (shorterThan.HasValue)
            {
                userModels = userModels.ShorterThan(shorterThan.Value);
            }

            if (tallerThan.HasValue)
            {
                userModels = userModels.TallerThan(tallerThan.Value);
            }

            if (youngerThan.HasValue)
            {
                userModels = userModels.YoungerThan(youngerThan.Value);
            }

            if (olderThan.HasValue)
            {
                userModels = userModels.OlderThan(olderThan.Value);
            }

            List<UserModel> users = await userModels.ToListAsync();

            if (!users.Any())
            {
                return StatusCode((int) HttpStatusCode.NotFound);
            }

            return StatusCode((int) HttpStatusCode.OK, new {totalCount = users.Count, users});
        }

        [HttpGet("query-via-repository/users")]
        public IActionResult GetUsersWithRepository([FromQuery] int? shorterThan, [FromQuery] int? tallerThan,
                                                    [FromQuery] int? olderThan, [FromQuery] int? youngerThan)
        {
            ExpressionSpecification<UserModel> specification = null;

            if (shorterThan.HasValue)
            {
                specification = new ShorterThanSpecification(shorterThan.Value);
            }

            if (tallerThan.HasValue)
            {
                var tallerThanSpecification = new TallerThanSpecification(tallerThan.Value);
                specification = specification?.And(tallerThanSpecification) ?? tallerThanSpecification;
            }

            if (youngerThan.HasValue)
            {
                var youngerThanSpecification = new YoungerThanSpecification(youngerThan.Value);
                specification = specification?.And(youngerThanSpecification) ?? youngerThanSpecification;
            }

            if (olderThan.HasValue)
            {
                var olderThanSpecification = new OlderThanSpecification(olderThan.Value);

                specification = specification?.And(olderThanSpecification) ?? olderThanSpecification;
            }

            List<UserModel> users = _userRepository.GetUsers(specification)
                                                   .ToList();

            if (!users.Any())
            {
                return StatusCode((int) HttpStatusCode.NotFound);
            }

            return StatusCode((int) HttpStatusCode.OK, new {totalCount = users.Count, users});
        }
    }
}