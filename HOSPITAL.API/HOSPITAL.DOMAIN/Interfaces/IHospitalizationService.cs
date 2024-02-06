using HOSPITAL.DOMAIN.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL.DOMAIN.Interfaces
{
    public interface IHospitalizationService
    {
        public Task<bool> SendToHospitalization(HospitalizationDTO hospitalizationDTO);
        public Task<bool> RejectAsync(string phone);
    }
}
