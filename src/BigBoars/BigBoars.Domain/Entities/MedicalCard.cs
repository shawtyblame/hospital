namespace BigBoars.Domain.Entities;
public class MedicalCard : BaseEntity
{
    public DateTime CreationalDate { get; set; }
    public int Number { get; set; }
    public User? User { get; set; }
}
