using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SoftwareAccounting.Common.Models;

var builder = WebApplication.CreateBuilder(args);

var options = builder.Configuration.GetSection("Settings");

builder.Services.Configure<AppSettings>(options);

