namespace Core.DataTypes;

public record Kaschde
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<FachData> Fach { get; set; }
}
