using BigBoars.Domain.Dtos;
using BigBoars.Domain.Entities;
using BigBoars.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BigBoars.Api.Controllers;
[Route("api/user")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        User? user = await userService.GetUserAsync(id);
        return user is not null ? Ok(user) : NotFound();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationDto registrationDto)
    {
        await userService.RegisterAsync(registrationDto);
        return Accepted();
    }

    [HttpPost("qr")]
    public async Task<IActionResult> GenerateQr(int userId, UserRequiredDto userRequiredDto)
    {
        userService.GenerateQrCode(userId, userRequiredDto);
        return Accepted();
    }

    [HttpPost("medical-card")]
    public async Task<IActionResult> CreateMedicalCard(int userId)
    {
        await userService.CreateMedicalCardAsync(userId);
        return Accepted();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(User user)
    {
        await userService.UpdateUserAsync(user);
        return Accepted();
    }

    [HttpPost("info")]
    public async Task<IActionResult> CreateUserInfo(UserInfoDto infoDto)
    {
        await userService.CreateInfoAsync(infoDto);
        return Accepted();
    }
}
