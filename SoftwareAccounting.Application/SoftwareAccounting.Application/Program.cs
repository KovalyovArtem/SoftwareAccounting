using Npgsql;
using Refit;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Domain.Repositories.Implementations;
using SoftwareAccounting.Domain.Repositories.Interfaces;
using SoftwareAccounting.Service.Extensions;
using SoftwareAccounting.Service.Services.ApiClientServices;
using SoftwareAccounting.Service.Services.Implementations;
using SoftwareAccounting.Service.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var options = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(options);
var appSettings = options.Get<AppSettings>();

builder.Services.AddHttpClient("AccountingClient")
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler())
    .AddTypedClient((client, services) =>
    {
        return RestService.For<IAccountingApiClient>(client);
    });

builder.Services.AddHttpClient();
builder.Services.AddTransient<IAccountingApiClientFactory, AccountingApiClientFactory>();

builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AuthSettings"));

builder.Services.AddSingleton(NpgsqlDataSource.Create(appSettings?.DbConnection ?? ""));

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IIntegrationDeviceService, IntegrationDeviceService>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IDevicesRepository, DevicesRepository>();
builder.Services.AddScoped<IIntegrationDeviceRepository, IntegrationDeviceRepository>();

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