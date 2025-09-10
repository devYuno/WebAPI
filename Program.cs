using Microsoft.EntityFrameworkCore;
using WittPid.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WittPid.Services.Users;
using WittPid.Services.JWT;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WittPidDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "WittPid",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });

builder.Services.AddSingleton<IJWTService, JWTService>();
builder.Services.AddTransient<IUserService, EFUserService>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
