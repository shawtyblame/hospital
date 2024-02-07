namespace BigBoars.Domain.Entities;
public class HealingEvent : BaseEntity
{
    public string? Name { get; set; }
    public DateTime? Time { get; set; }
    public string? Result { get; set; }
    public string? Recommendation { get; set; }
    public float? Cost { get; set; }
    public User? Patient { get; set; }
    public User? Doctor { get; set; }
    public HealingEventType? Type { get; set; }
    public RequestVisitation? RequestVisitation { get; set; }
}
