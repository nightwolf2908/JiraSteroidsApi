using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MediatR;
using JiraSteroids.Infrastructure;
using JiraSteroids.Infrastructure.Repositories;
using JiraSteroids.Domain;
using JiraSteroids.Application.Projects.Commands.CreateProject;

var builder = WebApplication.CreateBuilder(args);

// =========================================================================
// 1. CONFIGURACIÓN DE SERVICIOS (El contenedor de Inyección de Dependencias)
// =========================================================================

// Agregar los controladores tradicionales para la API
builder.Services.AddControllers();

// Configurar Swagger (La documentación interactiva en el navegador)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CONECTAR LA BASE DE DATOS: Le decimos a .NET que use PostgreSQL y busque la ruta en appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// REGISTRAR NUESTRO REPOSITORIO: "Cuando alguien pida IProjectRepository, dale un ProjectRepository real"
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// CONFIGURAR MEDIATR: Le enseñamos a MediatR dónde buscar los Handlers (en la capa de Aplicación)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProjectCommand).Assembly));

// CONFIGURAR FLUENTVALIDATION: Le enseñamos dónde buscar los Validadores
builder.Services.AddValidatorsFromAssembly(typeof(CreateProjectCommandValidator).Assembly);


// =========================================================================
// 2. CONFIGURACIÓN DEL PIPELINE HTTP (Qué pasa cuando entra una petición)
// =========================================================================
var app = builder.Build();

// Si estamos en desarrollo, activar la página visual de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Direccionar peticiones HTTP a HTTPS de forma segura
app.UseHttpsRedirection();

app.UseAuthorization();

// Mapear las rutas de nuestros controladores
app.MapControllers();

// Arrancar el servidor
app.Run();