using DI.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<IMiniContainer,MiniContainer>();
builder.Services.AddTransient<IMiniContainer,MiniContainer>();

using IHost host = builder.Build();

