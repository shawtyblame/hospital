using HospitalApp.Domain.DTOS;
using HospitalApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserService userService, ILogger<UserController> logger) : ControllerBase
    {

        private readonly ILogger<UserController> _logger = logger;
        private readonly IUserService _userService = userService;

        [HttpPost]
        [Route("/registration")]
        public async Task<IActionResult> Registration([FromBody]UserDTO userDTO) =>
            Ok(await _userService.RegistrationUserAsync(userDTO));
        [HttpGet]
        [Route("/getinfo")]
        public async Task<IActionResult> GetInfo(string number) =>
            Ok(await _userService.GetUserInfoByNumber(number));
        // TODO: Должен возвращать коды, а не 200 и IActionResult
        [HttpPost]
        [Route("/validate")]
        public async Task<IActionResult> Validate([FromBody] ValidateDTO validateDTO) =>
            Ok(await _userService.ValidateUser(validateDTO));
    }
}
