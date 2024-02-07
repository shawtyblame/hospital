using HospitalApp.Domain.Data;
using HospitalApp.Domain.DTOS;
using HospitalApp.Domain.Entities;
using HospitalApp.Domain.Interfaces;
using IronBarCode;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Application.Services
{
    public class UserService(AppDbContext context) : IUserService
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> RegistrationUserAsync(UserDTO userDTO)
        {
            var hasUser = await _context.UserMainInfos.FirstOrDefaultAsync(u => u.PhoneNumber == userDTO.PhoneNumber) 
                is null ? false : throw new ArgumentException("Пользователь уже зарегистрирован");
            var uniqueLogin = await _context.UserCredentials.FirstOrDefaultAsync(u => u.Login == userDTO.Login)
                is null ? false : throw new ArgumentException("Логин должен быть уникальным");
            var gender = await _context.Genders.FirstOrDefaultAsync(g => g.Name.ToLower().Equals(userDTO.Gender.ToLower()))
                ?? throw new ArgumentException("Гендера не существует");


            // TODO: Убрать привязку к константе RoleId
            await _context.UserCredentials.AddAsync(new UserCredential()
            {
                Login = userDTO.Login,
                Password = userDTO.Password,
                RoleId = 4,
            });
            await _context.SaveChangesAsync();
            var user = await _context.UserCredentials.FirstOrDefaultAsync(u => u.Login == userDTO.Login);

            await _context.UserMainInfos.AddAsync(new UserMainInfo()
            {
                Name = userDTO.Name,
                Lastname = userDTO.Lastname,
                Surname = userDTO.Surname,
                Email = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber,
                GenderId = gender.Id,
                PassportNumber = userDTO.PassportNumber,
                PassportSeries = userDTO.PassportSeries,
                UserId = user.Id
            });
            await _context.SaveChangesAsync();
            
            await _context.UserAdditionals.AddAsync(new UserAdditional(){
                DateOfBirth = userDTO.DateOfBirth,
                Address = userDTO.Address,
                WorkPlace = userDTO.WorkPlace,
                InsurancePolicyNumber = userDTO.InsurancePolicyNumber,
                InsurancePolicyDateEnd = userDTO.InsurancePolicyEndDate,
                UserMainInfoId = user.Id,
            });

            await _context.SaveChangesAsync();

            var random = new Random();
            long cardNumber = random.Next(100, 100000);
            GenerateQr(cardNumber);
            await _context.MedicalCards.AddAsync(new MedicalCard()
            {
                StartDate = DateTime.UtcNow,
                Number = cardNumber,
                UserMainInfoId = user.Id
            });
            await _context.SaveChangesAsync();
            return true;
        }
        public bool GenerateQr(long number)
        {
            // TODO: Убрать ключ в конфигурацию
            License.LicenseKey = "IRONSUITE.FOSIUSLEGEND.GMAIL.COM.16473-80AC91A93A-B7V2MGG-WHEEPUW6BPID-YCBSW2XDLGYT-ELFZLCOVNPMC-LUQKNRDOW5SX-EMZTKOJYGJYC-2RRPGZ3LN3LW-6J2FUL-TSFERM5ZOXKLUA-DEPLOYMENT.TRIAL-B5NOGC.TRIAL.EXPIRES.27.FEB.2024";
            var qr = BarcodeWriter.CreateBarcode($"{number}", BarcodeEncoding.QRCode);
            string rootPath = Directory.GetCurrentDirectory();
            string path = rootPath + @"Resources\QrCodes\";
            var filePath = Path.Combine(path, $"{number}" + ".jpeg");
            qr.SaveAsJpeg(filePath);
            return true;
        }

        public async Task<UserDTO> GetUserInfoByNumber(string number)
        {
            var user = await _context.UserMainInfos.FirstOrDefaultAsync(u => u.PhoneNumber.ToLower() == number.ToLower());
            var userInfo = await _context.UserAdditionals.FirstOrDefaultAsync(u => u.UserMainInfoId == user.Id);
            var userModel = new UserDTO
            {
                Name = user.Name,
                Lastname = user.Lastname,
                Surname = user.Surname,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                DateOfBirth = userInfo.DateOfBirth,
                PassportNumber = user.PassportNumber,
                PassportSeries = user.PassportSeries,
                Address = userInfo.Address,
                WorkPlace = userInfo.WorkPlace,
                InsurancePolicyEndDate = userInfo.InsurancePolicyDateEnd,
                InsurancePolicyNumber = userInfo.InsurancePolicyNumber,
            };
            return userModel;
        }

        public async Task<UserCredential> ValidateUser(ValidateDTO validateDTO)
        {
            var user = await _context.UserCredentials.FirstOrDefaultAsync(u => u.Login == validateDTO.Login && u.Password == validateDTO.Password 
                && (u.RoleId == 1 || u.RoleId == 2));
            return user;
        }
    }
}
