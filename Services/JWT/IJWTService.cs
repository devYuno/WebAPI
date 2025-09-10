namespace WittPid.Services.JWT;

public interface IJWTService
{
    string CreateToken(UserToAuth data); 
}