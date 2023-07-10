using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Repository;
using PlatformService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//EF
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));

//AutoMapper
builder.Services.AddAutoMapper(typeof(AppDbContext));

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app); 

app.Run();
