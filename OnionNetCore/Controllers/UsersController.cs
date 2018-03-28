using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnionNetCore.Core.DTOs;
using OnionNetCore.Core.Interfaces.Services;

namespace OnionNetCore.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private readonly IUserService _userApp;

        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userApp, ILogger<UsersController> logger)
        {
            _userApp = userApp;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all users");
            var users = _userApp.GetUsers();
            return Ok(users);
        }

        [HttpGet("{publicId}")]
        public IActionResult Get(string publicId)
        {
            return Ok(_userApp.GetUserById(publicId));
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserRequest user)
        {
            return Created(string.Empty, new { Id = _userApp.InsertUser(user) });
        }

        [HttpPut("{publicId}")]
        public IActionResult Put(string publicId, [FromBody]UserRequest user)
        {
            if (_userApp.UpdatetUser(publicId, user))
                return Ok();

            return NotFound();
        }

        [HttpDelete("{publicId}")]
        public IActionResult Delete(string publicId)
        {
            if (_userApp.DeleteUser(publicId))
                return Ok();

            return NotFound();
        }
    }
}
