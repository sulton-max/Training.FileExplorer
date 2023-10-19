var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.MapControllers();

app.Run();