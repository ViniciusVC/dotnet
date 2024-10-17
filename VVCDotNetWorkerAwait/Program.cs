using VVCDotNetWorkerAwait;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();

var host = builder.Build();

//host.Run();
await host.RunAsync();
