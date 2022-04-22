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
            return _userServices.ListUsers();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return _userServices.GetUser(id);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            
        }

        [HttpPut]
        public IActionResult Put(User user)
        {
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
        }
    }
}
