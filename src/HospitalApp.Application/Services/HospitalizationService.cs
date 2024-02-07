﻿using HospitalApp.Domain.Data;
using HospitalApp.Domain.DTOS;
using HospitalApp.Domain.Entities;
using HospitalApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Application.Services
{
    public class HospitalizationService(AppDbContext context) : IHospitalizationService
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> RejectAsync(string phone)
        {
            var user = await _context.UserMainInfos.FirstOrDefaultAsync(u => u.PhoneNumber ==  phone);
            var userHosp = await _context.Hospitalizations.FirstOrDefaultAsync(u => u.UserInfoId == user.Id);
            userHosp.HospitalizationStatusId = 2;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SendToHospitalization(HospitalizationDTO hospitalizationDTO)
        {
            var condition = await _context.HospitalizationConditions.FirstOrDefaultAsync(u => u.Name.ToLower().Equals(hospitalizationDTO.Condition.ToLower()));
            var departament = await _context.Departaments.FirstOrDefaultAsync(d => d.Name.ToLower().Equals(hospitalizationDTO.Departament.ToLower()));
            var user = await _context.UserMainInfos.FirstOrDefaultAsync(u => u.PhoneNumber == hospitalizationDTO.PhoneNumber);
            var  hospitalizationModel = new Hospitalization()
            {
                HospitalizationTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddDays(10),
                UserInfoId = user.Id,
                Diagnosis = hospitalizationDTO.Diagnosis,
                Target = hospitalizationDTO.Target,
                HospitalizationConditionId = condition.Id,
                DepartamentId = departament.Id,
                HospitalizationStatusId = 1
            };
            _context.Hospitalizations.Add(hospitalizationModel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
