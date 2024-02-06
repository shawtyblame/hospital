using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HOSPITAL.DOMAIN.Entities
{
    public class HealingEvent : EntityBase
    {
        public string? Name { get; set; }
        public DateTime? Time { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int HealingEventTypeId { get; set; }
        public string? Results { get; set; }
        public string? Recommendation { get; set; }
        public int RequestVisitId { get; set; }
        public float Price { get; set; }
        [JsonIgnore]
        public UserMainInfo? Patient { get; set; }
        [JsonIgnore]
        public UserMainInfo? Doctor { get; set; }
        [JsonIgnore]
        public HealingEventType? HealingEventType { get; set;}
        [JsonIgnore]
        public RequestVisit? RequestVisit { get; set; }
    }
}
