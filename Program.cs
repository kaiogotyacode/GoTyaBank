using CodeChallenge02.Database;
using CodeChallenge02.Repositories;
using CodeChallenge02.Repositories.Interfaces;
using CodeChallenge02.Services;
using CodeChallenge02.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PicPayContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddTransient<IUsuarioComumRepository, UsuarioComumRepository>();
builder.Services.AddTransient<ILojistaRepository, LojistaRepository>();
builder.Services.AddTransient<IEmailService, EmailService>();

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
