using HOSPITAL.DOMAIN.DTOS;
using HOSPITAL.DOMAIN.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HOSPITAL.API.Controllers
{
    [ApiController]
    [Route("/api/hospitalization")]
    public class HospitalizationController(IHospitalizationService hospitalizationService) : Controller
    {
        private readonly IHospitalizationService _hospitalizationService = hospitalizationService;

        [HttpPost]
        [Route("/sendto")]
        public async Task<IActionResult> SendTo([FromBody]HospitalizationDTO hospitalizationDTO) =>
            Ok(await _hospitalizationService.SendToHospitalization(hospitalizationDTO));

        [HttpPut]
        [Route("/reject")]
        public async Task<IActionResult> Reject(string phone) =>
            Ok(await _hospitalizationService.RejectAsync(phone));
    }
}
