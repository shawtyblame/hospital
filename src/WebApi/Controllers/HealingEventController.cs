using HospitalApp.Domain.DTOS;
using HospitalApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApp.Api.Controllers
{
    [ApiController]
    [Route("/api/controller")]
    public class HealingEventController(IHealingEventService healingEventService) : Controller
    {
        private readonly IHealingEventService _healingEventService = healingEventService;

        [HttpPost]
        [Route("/createrequest")]
        public async Task<IActionResult> CreateRequest(string phone, string name, string lastname) =>
            Ok(await _healingEventService.CreateRequestAsync(phone, name, lastname));
        [HttpPost]
        public async Task<IActionResult> CreateVisit(string phone, string name, string lastname, string rec, string notes) =>
            Ok(await _healingEventService.CreateVisitAsync(phone, name, lastname, rec, notes));
        [HttpPost]
        [Route("/createevent")]
        public async Task<IActionResult> CreateEvent(HealingEventDTO healingEventDTO) =>
            Ok(await _healingEventService.CreateEventAsync(healingEventDTO));
    }
}
