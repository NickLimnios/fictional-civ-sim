using Microsoft.EntityFrameworkCore;
using fcs.api.Data;
using fcs.api.Data.Repositories.Interfaces;
using fcs.api.Data.Repositories;
using fcs.api.Data.UnitOfWork.Interfaces;
using fcs.api.Data.UnitOfWork;
using fcs.api.Services.Interfaces;
using fcs.api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Get the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure DbContext to use SQLite
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICivilizationRepository, CivilizationRepository>();
builder.Services.AddScoped<ICivilizationService, CivilizationService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Use the CORS policy
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();