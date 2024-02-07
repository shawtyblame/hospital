using BigBoars.Domain.Dtos;
using BigBoars.Domain.Entities;

namespace BigBoars.Domain.Interfaces;
public interface IUserService
{
    public Task RegisterAsync(RegistrationDto registrationDto);
    public Task<bool> SignInAsync(UserCredentialsDto credentialsDto);
    public Task UpdateUserAsync(User user);
    public Task CreateInfoAsync(UserInfo userInfo);
    public Task GetUserAsync(int id);
}
