namespace Core;

public class Zeddel
{
    public required Guid Id { get; set; }
    public required string Question { get; set; }
    public required string Answer { get; set; }
    public List<Guid> TopicIds { get; set; }
}
