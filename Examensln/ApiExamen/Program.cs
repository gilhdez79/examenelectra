﻿using ApiExamen.Model;
using Microsoft.EntityFrameworkCore;
using ApiExamen.Controllers;
using ApiExamen.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProfesorEscuela, ProfesorEscuelaRepository>();
builder.Services.AddScoped<IAlumnos, AlumnoReposotory>();
builder.Services.AddScoped<IEscuela, EscuelaRepository>();
builder.Services.AddScoped<IProfesores, ProfesoresRepository>();
builder.Services.AddScoped<IProfesorEscuela, ProfesorEscuelaRepository>();





builder.Services.AddDbContext<EscuelaMusicContext>(
         context => context.UseSqlServer(builder.Configuration.GetConnectionString("main_sql")));

builder.Services.AddCors();
builder.Services.AddCors(o => o.AddPolicy("CorePolicy", builder =>
{
    builder.AllowAnyMethod();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();


app.Run();
