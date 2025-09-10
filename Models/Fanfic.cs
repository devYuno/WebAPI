namespace WittPid.Models;

public class Fanfic
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Text { get; set; }
    public required Guid CreatorId { get; set; }
    public required User Creator { get; set; }
    
    public ICollection<FanficList> Lists = [];
}