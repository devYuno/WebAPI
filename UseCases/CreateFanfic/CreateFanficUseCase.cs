using Microsoft.EntityFrameworkCore;
using WittPid.Models;
using WittPid.Services.Users;

namespace WittPid.UseCases.CreateFanfic;

public class CreateFanficUseCase(WittPidDbContext ctx, IUserService userService)
{
    public async Task<Result<CreateFanficResponse>> Do(CreateFanficPayload payload)
    {
        var creator = await userService.FindById(payload.UserId);

        var fanfic = new Fanfic
        {
            CreatorId = payload.UserId,
            Creator = creator,
            Title = payload.Title,
            Text = payload.Text
        };

        ctx.Fanfic.Add(fanfic);
        await ctx.SaveChangesAsync();

        return Result<CreateFanficResponse>.Fail("null");
    }
}