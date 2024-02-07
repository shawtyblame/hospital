namespace BigBoars.Domain.Entities;
public class UserInfo : BaseEntity
{
    public DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }
    public string? WorkPlace { get; set; }
    public int? InsurancePolicyNumber { get; set; }
    public DateTime InsurancePolicyEndDate { get; set; }
    public User? User { get; set; }
}
