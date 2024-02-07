using BigBoars.Domain.Entities;

namespace BigBoars.Domain.Dtos;
public class UserCredentialsDto : BaseEntity
{
    public string? Login { get; set; }
    public string? Password { get; set; }
}
