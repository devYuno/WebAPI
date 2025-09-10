using System.ComponentModel.DataAnnotations;

namespace WittPid.UseCases.Login;

public record LoginPayload
{
    [Required]
    public string Login { get; init; }

    [Required]
    public string Password { get; init; }
}