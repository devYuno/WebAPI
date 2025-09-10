using WittPid.Models;

namespace WittPid.Services.Users;

public interface IUserService
{
    Task<User> FindByLogin(string login);
    Task<User> FindById(Guid Id);
}