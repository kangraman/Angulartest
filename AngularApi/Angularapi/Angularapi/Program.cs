using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Angularapi;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<Startup>();
});

var host = builder.Build();

host.Run();