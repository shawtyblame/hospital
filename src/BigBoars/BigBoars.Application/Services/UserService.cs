using BigBoars.Domain.Dtos;
using BigBoars.Domain.Entities;
using BigBoars.Domain.Interfaces;
using BigBoars.EntityFramework.Data;
using IronBarCode;
using Microsoft.EntityFrameworkCore;

namespace BigBoars.Application.Services;
public class UserService(ApplicationDbContext context) : IUserService
{
    public async Task CreateInfoAsync(UserInfoDto userInfoDto)
    {
        User user = await context.Users.FirstAsync(x => x.Id == userInfoDto.UserId);
        await context.UserInfos.AddAsync(new()
        {
            Address = userInfoDto.Address,
            DateOfBirth = userInfoDto.DateOfBirth,
            InsurancePolicyEndDate = userInfoDto.InsurancePolicyEndDate,
            InsurancePolicyNumber = userInfoDto.InsurancePolicyNumber,
            User = user,
            WorkPlace = userInfoDto.WorkPlace
        });

        await context.SaveChangesAsync();
    }

    public async Task CreateMedicalCardAsync(int userId)
    {
        User user = await context.Users.FirstAsync(x => x.Id == userId); 
        var random = new Random();
        await context.MedicalCards.AddAsync(new()
        {
            CreationalDate = DateTime.UtcNow,
            Number = random.Next(100, 100000),
            User = user
        });
        await context.SaveChangesAsync();
    }

    public void GenerateQrCode(int userId, UserRequiredDto userRequiredDto)
    {
        var qr = BarcodeWriter.CreateBarcode($"{userId};{userRequiredDto}", BarcodeEncoding.QRCode);
        string rootPath = Directory.GetCurrentDirectory();
        string path = rootPath + @"Resources\QrCodes";
        string filePath = Path.Combine(path, $"{userId}.jpeg");
        qr.SaveAsJpeg(filePath);
    }

    // Также для qr
    public async Task<User?> GetUserAsync(int id)
    {
        return await context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task RegisterAsync(RegistrationDto registrationDto)
    {
        await IsExistBeforeAppendingUser(registrationDto);

        Role? role = await context.Roles.FirstOrDefaultAsync(x => x.Name!.ToLower() == "user");

        Gender? gender = await context.Genders
            .FirstOrDefaultAsync(g => g.Name!.ToLower().Equals(registrationDto!.UserRequired!.Gender!.ToLower()));

        await context.UserCredentials.AddAsync(new()
        {
            Login = registrationDto.UserCredentials!.Login,
            Password = registrationDto.UserCredentials.Password,
            Role = role
        });

        await context.SaveChangesAsync();

        UserCredentials? credentials = await context.UserCredentials
            .FirstOrDefaultAsync(x => x.Login == registrationDto.UserCredentials!.Login);

        await context.Users.AddAsync(new()
        {
            Name = registrationDto.UserRequired!.Name,
            LastName = registrationDto.UserRequired.LastName,
            Patronymic = registrationDto.UserRequired.Patronymic,
            PhoneNumber = registrationDto.UserRequired.Phone,
            Gender = gender,
            Credentials = credentials
        });

        await context.SaveChangesAsync();
    }

    public async Task<bool> SignInAsync(UserCredentialsDto credentialsDto)
    {
        return await context.UserCredentials.
            AnyAsync(x => x.Login == credentialsDto.Login 
            && x.Password == credentialsDto.Password);
    }

    public async Task UpdateUserAsync(User user)
    {
        User oldUser = await context.Users.FirstAsync(x => x.Id == user.Id);
        context.Entry(oldUser).CurrentValues.SetValues(user);
        await context.SaveChangesAsync();
    }

    private async Task<bool> IsExistBeforeAppendingUser(RegistrationDto registrationDto)
    {
        bool isExistUserDatas = await context.UserCredentials
            .AnyAsync(x => x.Login == registrationDto.UserCredentials!.Login) 
            && await context.Users
            .AnyAsync(x => x.PhoneNumber == registrationDto.UserRequired!.Phone) 
            is false? false : throw new ArgumentException("Пользователь уже существует");

        bool isExistGender =
            await context.Genders.AnyAsync(x => x.Name!.ToLower().Equals(registrationDto.UserRequired!.Gender!.ToLower()))
            is true ? true : throw new ArgumentException("Неверный гендер");

        return !isExistUserDatas && isExistGender;
    }
}
