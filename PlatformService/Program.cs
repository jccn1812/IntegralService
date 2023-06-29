using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//EF
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));

//AutoMapper
builder.Services.AddAutoMapper(typeof(AppDbContext));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
