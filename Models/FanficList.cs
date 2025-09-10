namespace WittPid.Models;

public class FanficList
{
    public required Guid Id { get; set; }
    public required Guid FanficId { get; set; }
    public required Fanfic Fanfic { get; set; }
    public required Guid ListId { get; set; }
    public required List List { get; set; }
    
    
}