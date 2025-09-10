namespace WittPid.Models;

public class User
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public string Description { get; set; }
    public required DateTime AccountCreatedOn { get; set; }

    public ICollection<Fanfic> CreatedFanfics = [];
    public ICollection<List> Lists = [];
}