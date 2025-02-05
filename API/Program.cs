using API.Authorization.Handlers;
using API.Authorization.Requirements;
using API.Extensions;
using Application.Commons.Mapping;
using Application.TaskLists.Commands.CreateTasksListCommand.Validator;
using Application.Users.Commands.CreateUserCommand;
using Domain.Interfaces.IUnitOfWork;
using DotNetEnv;
using DotNetEnv.Configuration;
using FluentValidation;
using Infrastructure.DbContexts;
using Infrastructure.Repositories.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Reflection;



var builder = WebApplication.CreateBuilder(args);

//DotNetEnv.Env.Load();
builder.Configuration.AddDotNetEnv(".env", LoadOptions.TraversePath()) 
    .Build();

builder.Services.AddControllersWithViews()
        .AddNewtonsoftJson(options =>
        {
            // Configure Newtonsoft.Json options here
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        });

builder.Services.AddCorsPolicy(builder.Configuration);
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
builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskListValidator>();
builder.Services.AddHttpClient();

var app = builder.Build();
app.UseCors("ReactApp");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
