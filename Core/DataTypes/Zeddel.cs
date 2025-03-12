namespace Core.DataTypes;

public record Zeddel
{
    public required Guid Id { get; set; }
    public required ZeddelContent Question { get; set; }
    public required ZeddelContent Answer { get; set; }
    public List<Topic> Topics { get; set; } = new();
}
