using Microsoft.EntityFrameworkCore;
using WittPid.Models;
using WittPid.Services.Users;

namespace WittPid.UseCases.DeleteFanfic;

public class DeleteFanficUseCase(WittPidDbContext ctx, IUserService userService)
{
    async Task<Result<DeleteFanficResponse>> Do(DeleteFanficPayload payload)
    {
        var user = await userService.FindById(payload.UserId);

        // if()
        // var validar = ctx.Fanfic.Id

        return Result<DeleteFanficResponse>.Success(new());
    }
}