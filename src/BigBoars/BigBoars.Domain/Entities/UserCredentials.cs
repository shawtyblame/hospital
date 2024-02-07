namespace BigBoars.Domain.Entities;
public class UserCredentials : BaseEntity
{
    public string? Login { get; set; }
    public string? Password { get; set; }
    public Role? Role { get; set; }
}
