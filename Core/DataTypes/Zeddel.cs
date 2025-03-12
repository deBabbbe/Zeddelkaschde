namespace Core.DataTypes;

public class Zeddel
{
    public required Guid Id { get; set; }
    public required ZeddelContent Question { get; set; }
    public required ZeddelContent Answer { get; set; }
    public List<Topic> Topics { get; set; }
}
