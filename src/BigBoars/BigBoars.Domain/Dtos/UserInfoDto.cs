namespace BigBoars.Domain.Dtos;
public class UserInfoDto
{
    public DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }
    public string? WorkPlace { get; set; }
    public int? InsurancePolicyNumber { get; set; }
    public DateTime InsurancePolicyEndDate { get; set; }
    public int UserId { get; set; }
}
