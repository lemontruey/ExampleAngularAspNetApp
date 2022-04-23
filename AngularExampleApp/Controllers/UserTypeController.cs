namespace AngularExampleApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using AngularExampleApp.Core.Services;
    using AngularExampleApp.Core.Models.Mappings;

    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : Controller
    {
        IService<UserTypeMapping> _userTypeService;
        public UserTypeController(IService<UserTypeMapping> userTypeServices)
        {
            _userTypeService = userTypeServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userTypeService.List());
        }

        [HttpPost]
        public IActionResult Post(UserTypeMapping userType)
        {
            if (ModelState.IsValid)
            {
                return Ok(_userTypeService.Add(userType));
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(UserTypeMapping userType)
        {
            if (ModelState.IsValid)
            {
                return Ok(_userTypeService.Edit(userType));
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
