namespace Core;

public class Zeddel
{
    public Guid Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public List<Guid> TopicIds { get; set; }
}
