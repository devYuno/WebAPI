namespace WittPid.Models;

public class List
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required Guid CreatorId { get; set; }
    public required User Creator { get; set; }
    public required DateTime LastModified { get; set; }
    public ICollection<FanficList> Fanfics = [];
}