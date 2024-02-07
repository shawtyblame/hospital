namespace BigBoars.Domain.Entities;
public class RequestVisitation : BaseEntity
{
    public DateTime VisitDate { get; set; }
    public User? Visitor { get; set; }
    public User? Doctor { get; set; }
}
