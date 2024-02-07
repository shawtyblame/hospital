namespace BigBoars.Domain.Entities;
public class Hospitalization : BaseEntity
{
    public DateTime? HospitalizationTime { get; set; }
    public DateTime? HospitalizationEndTime { get; set; }
    public string? Diagnosis {  get; set; }
    public string? Target { get; set; }
    public User? Patient { get; set; }
    public HospitalizationCondition? Condition { get; set; }
    public Departament? Departament { get; set; }
    public Status? Status { get; set; }
}
