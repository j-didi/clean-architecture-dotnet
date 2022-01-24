using CleanArchDotnet.API.Common;
using CleanArchDotnet.Infra.IoC;
using CleanArchDotnet.Infra.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

var settings = builder.Configuration.Get<AppSettings>();
builder.Services.InjectAppDependencies(settings);

var app = builder.Build();
app.ApplyMigrations();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();