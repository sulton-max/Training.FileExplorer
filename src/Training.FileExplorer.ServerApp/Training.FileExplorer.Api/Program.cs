using Training.FileExplorer.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

await builder.ConfigureAsync();
var app = builder.Build();

await app.AddBrokers();
await app.RunAsync();