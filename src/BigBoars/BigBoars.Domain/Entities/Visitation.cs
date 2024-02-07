namespace BigBoars.Domain.Entities;
public class Visitation : BaseEntity
{
    public string? Recommendation { get; set; }
    public string? Notes { get; set; }
    public RequestVisitation? RequestVisitation { get; set; }
    public User? Doctor { get; set; }
    public MedicalCard? PatientMedicalCard { get; set; }
}
