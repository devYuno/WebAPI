using System.ComponentModel.DataAnnotations;

namespace WittPid.UseCases.DeleteFanfic;

public record DeleteFanficPayload
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public Guid FanficId { get; set; }
}