using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PruebaTecnica.Application.Exceptions;
using PruebaTecnica.Application.Exceptions.Interfaces;
using PruebaTecnica.Application.Features.EventsLog.V1;
using PruebaTecnica.Infrastructure.Context;
using PruebaTecnica.Infrastructure.Options;
using PruebaTecnica.Infrastructure.Repository;
using PruebaTecnica.Infrastructure.Repository.Contracts;
using PruebaTecnica.Infrastructure.UnitOfWork;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PruebaTecnicaWriteContext>(options =>
{
    DbContextOptionsSetup.ConfigureWriteOptions(options, builder.Configuration.GetConnectionString("PruebaTecnicaDbConnection"));
});

builder.Services.AddDbContext<PruebaTecnicaReadContext>(options =>
{
    DbContextOptionsSetup.ConfigureReadOptions(options, builder.Configuration.GetConnectionString("PruebaTecnicaDbConnection"));
});

foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
}

builder.Services.AddTransient<IEventLogRepository, EventLogRepository>();
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddTransient<PruebaTecnicaWriteContext>();
builder.Services.AddExceptionServices(typeof(LoadExceptionAssembly).Assembly);

builder.Services.AddValidationsAndServicesEventsLog();

builder.Services.AddCarter();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        );
});

var app = builder.Build();

app.UseExceptionHandlerMiddleware(app.Environment, app.Services.GetRequiredService<IExceptionHandlerService>()!);

// Ejecutar migraciones y seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PruebaTecnicaWriteContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.MapCarter();
app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
