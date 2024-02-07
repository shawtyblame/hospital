using BigBoars.Domain.Dtos;
using BigBoars.Domain.Entities;

namespace BigBoars.Domain.Interfaces;
public interface IUserService
{
    public Task RegisterAsync(RegistrationDto registrationDto);
    public Task<bool> SignInAsync(UserCredentialsDto credentialsDto);
    public Task CreateMedicalCardAsync(int userId);
    public Task UpdateUserAsync(User user);
    public Task CreateInfoAsync(UserInfoDto userInfoDto);
    public Task<User?> GetUserAsync(int id);
    public void GenerateQrCode(int userId, UserRequiredDto userRequiredDto);
}
