using Microsoft.EntityFrameworkCore;
using Playstation.Api;
using Playstation.Application;
using Playstation.Infrastructure;
using Playstation.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwagger();
builder.Services.AddApplication(builder.Environment, builder.Configuration)
                .AddDataAccess(builder.Configuration);

builder.Services.AddDbContext<PlayStationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();
using var scope = app.Services.CreateScope();

await AutomatedMigration.MigrateAsync(scope.ServiceProvider);

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
