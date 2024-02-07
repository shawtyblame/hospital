namespace BigBoars.Domain.Dtos;
public class UserRequiredDto
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }
    public string? Phone { get; set; }
    public string? Gender { get; set; }
    public override string ToString() =>
        $"{Name};{LastName};{Phone}";
}
