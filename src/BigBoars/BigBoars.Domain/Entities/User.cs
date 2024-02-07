namespace BigBoars.Domain.Entities;
public class User : BaseEntity
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PassportSeries { get; set; }
    public string? PassportNumber { get; set; }
    public Gender? Gender { get; set; }
    public UserCredentials? Credentials { get; set; }
}
