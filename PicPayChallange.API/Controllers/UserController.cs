using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicPayChallange.API.Models.Dtos;
using PicPayChallange.API.Services;

namespace PicPayChallange.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly IUserModelService _userModelService;

        public UserController(IUserModelService userModelService) {
            _userModelService = userModelService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserModelRequestDTO userRequestDTO) {

            try {
                await _userModelService.CreateUser(userRequestDTO);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message); 
            }
        }
    }
}
