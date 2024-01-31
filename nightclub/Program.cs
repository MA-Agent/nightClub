using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nightclub.Entities;
using nightclub.Interfaces;
using nightclub.Mapping;
using nightclub.Models;
using nightclub.Services.Db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Initialize AutoMapper
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddDbContext<DbNightClubContext>();

//Services with Db access for Dependency injection
builder.Services.AddTransient<IMemberService, MemberService>();

//Add models for dependency injection
builder.Services.AddTransient<MemberModel, MemberModel>();

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
