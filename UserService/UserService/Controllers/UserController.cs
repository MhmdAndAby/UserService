using Microsoft.AspNetCore.Mvc;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;

namespace UserService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IEndUserService userService) : ControllerBase
    {
        private readonly IEndUserService _userService = userService;
       
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            await _userService.CreateAsync(userDto);
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);
            if (userDto == null)
            {
                return NotFound();
            }
            return Ok(userDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id,UserDto userDto)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userService.UpdateAsync(id, userDto);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }

            await _userService.DeleteAsync(id);
            return NoContent();
        }

        

    }
}
