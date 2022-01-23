global using MediatR;
global using Microservice.NETCore.V6.Application.Common.Events;
global using Microservice.NETCore.V6.Application.Features.Dispatches.Queries;
global using Microservice.NETCore.V6.Controllers.Base;
global using Microsoft.AspNetCore.Mvc;
global using System.ComponentModel.DataAnnotations;

using Microservice.NETCore.V6.Application.Common.Options;
using Microservice.NETCore.V6.Application.Features.Dispatches.Handlers;
using Microservice.NETCore.V6.Application.Filters;
using Microservice.NETCore.V6.Application.Interfaces.Repositories;
using Microservice.NETCore.V6.Infrastructure;
using Microservice.NETCore.V6.Infrastructure.Dispatches;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    //Add Filters to controllers
    options.Filters.Add(typeof(ExceptionsAttribute));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add IMediator Assemblies
builder.Services.AddMediatR(typeof(GetDispatchesEventHandler));

// Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add Injected Dependency
builder.Services.AddTransient<IDispatchesRepository, DispatchesRepository>();

// Add IOptions
builder.Services.Configure<DispatchOptions>(builder.Configuration.GetSection(DispatchOptions.Dispatch));

// Add Http Clients
builder.Services.AddHttpClients(builder.Configuration);

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