using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WittPid.UseCases.CreateFanfic;

namespace WittPid.Endpoints;

public static class UserEndpoints
{
    public static void ConfigureUserEndpoints(this WebApplication app)
    {
        app.MapPost("user/{id}/newfanfic/", async (
            Guid id,
            HttpContext http,
            [FromBody] CreateFanficPayload payload,
            [FromServices] CreateFanficUseCase usecase
        ) =>
        {
    
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            var result = await usecase.Do(payload);
            return Results.Created($"/fanfic/{result.Data.FanficId}", result);
        }).RequireAuthorization();
    }
}