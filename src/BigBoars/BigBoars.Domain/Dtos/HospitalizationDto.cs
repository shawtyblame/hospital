using BigBoars.Domain.Entities;

namespace BigBoars.Domain.Dtos;
public class HospitalizationDto
{
    public DateTime? HospitalizationTime { get; set; }
    public DateTime? HospitalizationEndTime { get; set; }
    public string? Target { get; set; }
    public int PatientId { get; set; }
    public int ConditionId { get; set; }
    public int DepartamentId { get; set; }
}
