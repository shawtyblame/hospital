﻿using HospitalApp.Domain.Data;
using HospitalApp.Domain.DTOS;
using HospitalApp.Domain.Entities;
using HospitalApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Application.Services
{
    public class HealingEventService(AppDbContext context) : IHealingEventService
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> CreateEventAsync(HealingEventDTO healingEventDTO)
        {
            var user = await _context.UserMainInfos.FirstOrDefaultAsync(u => u.PhoneNumber == healingEventDTO.PatientPhone);
            var doctor = await _context.UserMainInfos.FirstOrDefaultAsync(u => u.Name == healingEventDTO.DoctorName 
                && u.Lastname == healingEventDTO.DoctorLastName);
            var request = await _context.RequestVisits.FirstOrDefaultAsync(r => r.VisitorId == user.Id);
            var healingEventType = await _context.HealingEventTypes.FirstOrDefaultAsync(u => u.Name.ToLower().Equals(healingEventDTO.HealingEventType.ToLower()));
            var healingEventModel = new HealingEvent()
            {
                Name = healingEventDTO.Name,
                Time = healingEventDTO.Time,
                PatientId = user.Id,
                DoctorId = doctor.Id,
                HealingEventTypeId = healingEventType.Id,
                Results = healingEventDTO.Result,
                Recommendation = healingEventDTO.Recommendation,
                RequestVisitId = request.Id,
                Price = healingEventDTO.Price,
            };
            _context.HealingEvents.Add(healingEventModel);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateRequestAsync(string phone, string name, string lastname)
        {
            var user = await _context.UserMainInfos.FirstOrDefaultAsync(u => u.PhoneNumber == phone);
            var doctor = await _context.UserMainInfos.FirstOrDefaultAsync(u => u.Name == name && u.Lastname == lastname);
            if (user == null || doctor == null) throw new ArgumentException("Error");

            var requestModel = new RequestVisit()
            {
                DateTime = DateTime.UtcNow,
                VisitorId = user.Id,
                DoctorId = doctor.Id,
            };

            _context.RequestVisits.Add(requestModel);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateVisitAsync(string phone, string name, string lastname, string rec, string notes)
        {
            var user = await _context.UserMainInfos.FirstOrDefaultAsync(u => u.PhoneNumber == phone);
            var doctor = await _context.UserMainInfos.FirstOrDefaultAsync(u => u.Name == name && u.Lastname == lastname);
            var medicalCard = await _context.MedicalCards.FirstOrDefaultAsync(m => m.UserMainInfoId == user.Id);
            var request = await _context.RequestVisits.FirstOrDefaultAsync(r => r.VisitorId == user.Id);
            if (medicalCard == null || doctor == null) throw new ArgumentException("Error");
            var visitModel = new Visit()
            {
                MedicalCardId = medicalCard.Id,
                Recommendation = rec,
                Notes = notes,
                DoctorId = doctor.Id,
                RequestVisitId = request.Id,
            };
            _context.Visits.Add(visitModel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
