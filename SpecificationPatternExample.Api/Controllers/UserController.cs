using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpecificationPatternExample.Api.Specifications;
using SpecificationPatternExample.Data;
using SpecificationPatternExample.Data.Models;

namespace SpecificationPatternExample.Api.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromQuery] int? shorterThan, [FromQuery] int? tallerThan,
                                                  [FromQuery] int? olderThan, [FromQuery] int? youngerThan,
                                                  [FromQuery] int offset = 0, [FromQuery] int limit = 10)
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

            int totalCount = await userModels.CountAsync();

            List<UserModel> users = await userModels.Skip(offset)
                                                    .Take(limit)
                                                    .ToListAsync();

            if (!users.Any())
            {
                return StatusCode((int) HttpStatusCode.NotFound);
            }

            return StatusCode((int) HttpStatusCode.OK, new {totalCount, users});
        }
    }
}