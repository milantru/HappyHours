using HappyHoursData;
using HappyHoursData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HappyHoursAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            using var context = new HappyHoursDbContext();

            return await context.Users.ToListAsync();
        }
    }
}
