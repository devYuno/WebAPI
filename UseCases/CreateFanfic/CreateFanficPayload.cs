using System.ComponentModel.DataAnnotations;

namespace WittPid.UseCases.CreateFanfic;

public record CreateFanficPayload
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(30)]
    public string Title { get; init; }

    [Required]
    [MinLength(300)]
    [MaxLength(6000)]
    public string Text { get; init; }
}