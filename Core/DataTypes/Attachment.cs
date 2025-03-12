namespace Core.DataTypes;

public record Attachment
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public byte[] Data { get; set; }
    public string ContentType { get; set; }

    public Guid ZeddelContentId { get; set; }
    public ZeddelContent ZeddelContent { get; set; } = null!;
}
