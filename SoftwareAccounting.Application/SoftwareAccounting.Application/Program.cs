using Npgsql;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Domain.Repositories.Implementations;
using SoftwareAccounting.Domain.Repositories.Interfaces;
using SoftwareAccounting.Service.Extensions;
using SoftwareAccounting.Service.Services.Implementations;
using SoftwareAccounting.Service.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var options = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(options);
var appSettings = options.Get<AppSettings>();

builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AuthSettings"));

builder.Services.AddSingleton(NpgsqlDataSource.Create(appSettings?.DbConnection ?? ""));

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddAuth(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();