namespace Core.DataTypes;

public record FachData
{
    public Guid Id { get; set; }
    public EPriority Priority { get; set; }
    public Zeddel Zeddel { get; set; }
}
