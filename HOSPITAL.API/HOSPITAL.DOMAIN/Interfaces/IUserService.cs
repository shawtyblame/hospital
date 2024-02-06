using HOSPITAL.DOMAIN.DTOS;
using HOSPITAL.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL.DOMAIN.Interfaces
{
    public interface IUserService
    {
        public Task<bool> RegistrationUserAsync(UserDTO userDTO);
        public Task<UserDTO> GetUserInfoByNumber(string number);
        public Task<UserCredential> ValidateUser(ValidateDTO validateDTO);
    }
}
