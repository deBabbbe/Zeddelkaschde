namespace Core.DataTypes;

public class ZeddelContent
{
    public required Guid Id { get; set; }
    public required string Text { get; set; }
    public IEnumerable<Attachment> Attachments { get; set; }
}
