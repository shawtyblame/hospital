using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalApp.Domain.Entities
{
    public class Hospitalization : EntityBase
    {
        public DateTime? HospitalizationTime { get; set; }
        public DateTime? EndTime { get;set; }
        public int UserInfoId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Target { get; set; }
        public int DepartamentId { get; set; }
        public int HospitalizationConditionId { get; set; }
        public int HospitalizationStatusId { get; set; }
        [JsonIgnore]
        public UserMainInfo? UserInfo { get; set; }
        [JsonIgnore]
        public Departament? Departament { get; set; }
        [JsonIgnore]
        public HospitalizationCondition HospitalizationCondition { get; set; }
        [JsonIgnore]
        public HospitalizationStatus? HospitalizationStatus { get; set;}
    }

}
