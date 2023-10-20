using System.Reflection;
using FileExplorer.Application.FileStorage.Brokers;
using FileExplorer.Infrastructure.FileStorage.Brokers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// Assembly.GetExecutingAssembly().GetTypes().
var assemblies = Assembly
    .GetExecutingAssembly() // hozirgi run qilingan assemblyni olish
    .GetReferencedAssemblies() // bu shu projectga reference qilingan assemblylarni olish
    .Select(Assembly.Load)
    .ToList();

assemblies.Add(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(assemblies);

builder.Services.AddSingleton<IDriveBroker, DriveBroker>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        config.AllowAnyHeader();
        config.AllowAnyMethod();
        config.AllowAnyOrigin();
    });
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.MapControllers();

app.Run();