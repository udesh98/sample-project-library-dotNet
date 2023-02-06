using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using my_library.Data;
using my_library.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext with SQL
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

// Configure the Services
builder.Services.AddTransient<BooksService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Seeding database with some initial data
AppDbInitializer.Seed(app);

app.Run();
