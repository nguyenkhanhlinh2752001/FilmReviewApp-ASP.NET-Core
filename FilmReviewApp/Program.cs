using FilmActorApp.Database;
using FilmReviewApp.Interfaces;
using FilmReviewApp.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add this code
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//************Add this code**********
builder.Services.AddScoped<IFilm, FilmRepository>();
builder.Services.AddScoped<ICategory, CategoryRepository>();

//****Connect Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));
//****

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

app.Run();
