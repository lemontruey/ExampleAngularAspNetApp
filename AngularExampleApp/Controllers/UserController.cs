namespace AngularExampleApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using AngularExampleApp.Core.Models;
    using AngularExampleApp.Core.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        IUserService _userServices;
        public UsersController(IUserService userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userServices.ListUsers());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {            
            return Ok(_userServices.GetUser(id));
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            if (ModelState.IsValid)
            {
                return Ok(_userServices.AddUser(user));
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(User user)
        {
            if (ModelState.IsValid)
            {
                return Ok(_userServices.EditUser(user));
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userServices.DeleteUser(id);
            return Ok();
        }
    }
}
