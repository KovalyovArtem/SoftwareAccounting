using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SoftwareAccounting.Common.Models;
using SoftwareAccounting.Library.Services.ActiveUtilityServices.Implementations;
using SoftwareAccounting.Library.Services.ActiveUtilityServices.Interfaces;
using SoftwareAccounting.Library.Services.ApiClients;
using SoftwareAccounting.Library.Services.DeviceScan.Implementations;
using SoftwareAccounting.Library.Services.DeviceScan.Interfaces;
using SoftwareAccounting.Worker;
using Refit;

var pathToExe = Environment.ProcessPath;
string pathToContentRoot = Path.GetDirectoryName(pathToExe);
WebApplicationOptions appOptions = new WebApplicationOptions
{
    ContentRootPath = pathToContentRoot
};

var builder = WebApplication.CreateBuilder(args);

var options = builder.Configuration.GetSection("Settings");
builder.Services.Configure<AppSettings>(options);
var appSettings = options.Get<AppSettings>();

if (!string.IsNullOrEmpty(appSettings?.ApiServiceUrl))
{
    builder.Services.AddRefitClient<ISoftwareAccountingApiClient>().ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(appSettings?.ApiServiceUrl);
    });
}

builder.Services.AddScoped<IActiveService, ActiveService>();

if (OperatingSystem.IsWindows())
{
    builder.Services.AddSingleton<IDeviceScan, WindowsDeviceScan>();
}
else if (OperatingSystem.IsLinux())
{

}
else if (OperatingSystem.IsIOS() || OperatingSystem.IsMacOS())
{

}
else
{
    throw new NotImplementedException("Не удалось определить операционную систему");
}

builder.Services.AddHostedService<Worker>();
builder.Services.AddWindowsService();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SoftwareAccountingService API", Version = "v1" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

    foreach (var file in Directory.EnumerateFiles(builder.Environment.ContentRootPath, "*.xml", SearchOption.TopDirectoryOnly))
    {
        c.IncludeXmlComments(file, includeControllerXmlComments: true);
    }
});

builder.Services.AddWindowsService();

var app = builder.Build();

app.UseCors(builder =>
            builder.SetIsOriginAllowed(origin => true)
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();