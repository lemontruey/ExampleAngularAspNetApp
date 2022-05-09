namespace AngularExampleApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using AngularExampleApp.Core.Services;
    using AngularExampleApp.Core.Models.Mappings;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IService<UserMapping> _userTypeService;
        public UserController(IService<UserMapping> userTypeService)
        {
            _userTypeService = userTypeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userTypeService.List());
        }

        [HttpPost]
        public IActionResult Post(UserMapping user)
        {
            if (ModelState.IsValid)
            {
                return Ok(_userTypeService.Add(user));
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(UserMapping user)
        {
            if (ModelState.IsValid)
            {
                return Ok(_userTypeService.Edit(user));
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userTypeService.Delete(id);
            return Ok();
        }
    }
}
