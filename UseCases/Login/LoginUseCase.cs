using WittPid.Services.JWT;
using WittPid.Services.Users;


namespace WittPid.UseCases.Login;

public record LoginUseCase(IJWTService JWTService, IUserService userService)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await userService.FindByLogin(payload.Login);

        if (user is null)
            return Result<LoginResponse>.Fail("User not found!");


        var pass = user.Password == payload.Password;

        if (!pass)
            return Result<LoginResponse>.Fail("Incorrect Password");

        var userdata = new UserToAuth(user.Id, user.Username);

        var jwt = JWTService.CreateToken(userdata);

        return Result<LoginResponse>.Success(new(jwt));
    }
}

