using HospitalApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Domain.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Departament> Departaments => Set<Departament>();
        public DbSet<Gender> Genders => Set<Gender>();
        public DbSet<HealingEvent> HealingEvents => Set<HealingEvent>();    
        public DbSet<HealingEventType> HealingEventTypes => Set<HealingEventType>();
        public DbSet<Hospitalization> Hospitalizations => Set<Hospitalization>();
        public DbSet<HospitalizationCondition> HospitalizationConditions => Set<HospitalizationCondition>();
        public DbSet<HospitalizationStatus> HospitalizationStatuses => Set<HospitalizationStatus>();
        public DbSet<MedicalCard> MedicalCards  => Set<MedicalCard>();
        public DbSet<RequestVisit> RequestVisits => Set<RequestVisit>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserAdditional> UserAdditionals => Set<UserAdditional>();
        public DbSet<UserCredential> UserCredentials => Set<UserCredential>();
        public DbSet<UserMainInfo> UserMainInfos => Set<UserMainInfo>();
        public DbSet<Visit> Visits => Set<Visit>();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}
