using Microsoft.EntityFrameworkCore;
using fcs.api.Data;
using fcs.api.Data.Repositories.Interfaces;
using fcs.api.Data.Repositories;
using fcs.api.Data.UnitOfWork.Interfaces;
using fcs.api.Data.UnitOfWork;
using fcs.api.Services.Interfaces;
using fcs.api.Services;
using fcs.api.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure DbContext to use SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Data/civilization.db")); // Path to SQLite database file

// Alternatively, configure DbContext to use in memory db
// builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("CivilizationDb"));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICivilizationRepository, CivilizationRepository>();
builder.Services.AddScoped<ICivilizationService, CivilizationService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFCSUIApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://ui") // Allow fcs.ui app
              .AllowAnyHeader()                   // Allow any headers
              .AllowAnyMethod();                  // Allow any HTTP methods
    });
});

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

//Seed for in memory db
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//    DataSeeder.SeedData(context);
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();