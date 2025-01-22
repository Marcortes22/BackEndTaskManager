using API.Authorization.Handlers;
using API.Authorization.Requirements;
using API.Extensions;
using Application.Commons.Mapping;
using Application.Users.Commands.CreateUserCommand;
using Domain.Interfaces.IUnitOfWork;
using DotNetEnv;
using DotNetEnv.Configuration;
using Infrastructure.DbContexts;
using Infrastructure.Repositories.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;



var builder = WebApplication.CreateBuilder(args);

//DotNetEnv.Env.Load();
builder.Configuration.AddDotNetEnv(".env", LoadOptions.TraversePath()) 
    .Build();

builder.Services.AddCorsPolicy();
builder.Services.AddDatabaseConfiguration(builder.Configuration["MySqlConnection"]);
builder.Services.AddAuth0Authentication(builder.Configuration);
builder.Services.AddAuth0Authorization(builder.Configuration);

builder.Services.AddServices();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateUserCommandHandler>());

builder.Services.AddAutoMapper(typeof(AutoMapperUser).Assembly);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

var app = builder.Build();
app.UseCors("ReactApp");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
