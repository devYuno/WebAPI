using Microsoft.EntityFrameworkCore;
using WittPid.Models;

namespace WittPid.Services.Users;

public class EFUserService(WittPidDbContext ctx) : IUserService
{
    public async Task<User> FindByLogin(string login)
    {
        var user = await ctx.User.FirstOrDefaultAsync(
            u => u.Username == login || u.Email == login
        );

        return user;
    }

    public async Task<User> FindById(Guid Id)
    {
        var user = await ctx.User.FirstOrDefaultAsync(
            u => u.Id == Id
        );

        return user;
    }
}