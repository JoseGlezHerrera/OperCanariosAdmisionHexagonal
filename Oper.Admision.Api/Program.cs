using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using Oper.Admision.Api;
using Oper.Admision.Api.Configuracion;
using Oper.Admision.Api.Middlewares;
using Oper.Admision.Application;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Logs;
using Oper.Admision.Infrastructure;
using Oper.Admision.Infrastructure.Correo;
using Oper.Admision.Infrastructure.Repositories;
using Serilog;
using System.Text;
using AutoMapper;

// Mappings
using Oper.Admision.Api.UseCases.Usuarios.LoginUsuario;
using Oper.Admision.Api.UseCases.Problematicos.ActualizarProblematico;
using Oper.Admision.Api.UseCases.Problematicos.ObtenerProblematicoID;

// UseCases
using Oper.Admision.Application.UseCases.Problematico.ActualizarProblematico;
using Oper.Admision.Application.UseCases.Problematico.EliminarProblematico;
using Oper.Admision.Application.UseCases.Problematico.FiltrarProblematicoPorTipo;
using Oper.Admision.Application.UseCases.Socios.GetSocio;
using Oper.Admision.Application.UseCases.Socios;
using Oper.Admision.Application.UseCases.Usuarios.Crear;
using Oper.Admision.Application.UseCases.Usuarios.Login;
using Log = Serilog.Log;

//Visitas
using Oper.Admision.Application.UseCases.Visitas.CrearVisita;
using Oper.Admision.Application.UseCases.Socios.EliminarSocio;
using Oper.Admision.Application.UseCases.Socios.ObtenerSocioPorId;
using Oper.Admision.Application.UseCases.Visitas.ActualizarVisita;
using Oper.Admision.Application.UseCases.Visitas.ObtenerVisitaPorId;
using Oper.Admision.Api.UseCases.Visitas.ObtenerVisitaPorId;
using Oper.Admision.Application.UseCases.Visita.EliminarVisita;
using Oper.Admision.Application.UseCases.Visita.ObtenerVisitaPorId;
using Oper.Admision.Api.UseCases.Visitas.ObtenerVisitasPorFecha;
using Oper.Admision.Application.UseCases.Visitas.ObtenerVisitasPorFecha;
using Oper.Admision.Application.UseCases.Socios.GetSocioProhibido;
using Oper.Admision.Application.UseCases.Visitas.RegistrarVisita;
using Oper.Admision.Application.UseCases.Socios.ValidarSocio;
using Oper.Admision.Infrastructure.Seguridad;
using Oper.Admision.Domain;
using Oper.Admision.Application.UseCases.Usuarios.CambiarPassword;
using Oper.Admision.Application.UseCases.Rol.GetRoles;
using Oper.Admision.Application.UseCases.Visitas.GetVisitasPorSocioId;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

// Logger
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

Log.Information("Arranque servidor ASP.NET");

// JSON cycles + CORS
services.AddControllers().AddJsonOptions(opt =>
    opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Swagger
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// Form limits
services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = int.MaxValue;
    options.MultipartHeadersLengthLimit = int.MaxValue;
});
services.Configure<IISServerOptions>(o => o.MaxRequestBodySize = int.MaxValue);
services.Configure<KestrelServerOptions>(o => o.Limits.MaxRequestBodySize = int.MaxValue);

// AutoMapper y UseCases
builder.Services.AddScoped<EliminarSocioUseCase>();
builder.Services.AddScoped<ObtenerSocioPorIdUseCase>();
builder.Services.AddScoped<CrearVisitaUseCase>();
builder.Services.AddScoped<ActualizarVisitaUseCase>();
builder.Services.AddScoped<EliminarVisitaUseCase>();
builder.Services.AddScoped<GetVisitasPorSocioIdUseCase>();
builder.Services.AddScoped<ObtenerVisitaPorIdUseCase>();
builder.Services.AddScoped<ObtenerVisitasPorFechaUseCase>();
builder.Services.AddScoped<ActualizarProblematicoUseCase>();
builder.Services.AddScoped<GetSocioProhibidoUseCase>();
builder.Services.AddScoped<RegistrarVisitaUseCase>();
builder.Services.AddScoped<ValidarSocioUseCase>();
builder.Services.AddScoped<IGestionUOW, GestionUOW>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<CambiarPasswordUsuarioUseCase>();
builder.Services.AddScoped<JwtGenerator>();
builder.Services.AddScoped<LoginUsuarioUseCase>();
builder.Services.AddScoped<IUsuarioApi, UsuarioApi>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<GetRolesUseCase>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();


// Authentication
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["JWT:Issuer"],
            ValidAudience = configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"]))
        };
    });

// Configuración y capas
services.Configure<Dominio>(configuration.GetSection("Dominio"));
services.Configure<ConfigCorreo>(configuration.GetSection("ConfigCorreo"));
services.AddApiLayer(configuration);
services.AddInfrastructureLayer(configuration);
services.AddApplicationLayer();

// Repositorios
services.AddScoped<IUsuarioApi, UsuarioApi>();
services.AddScoped<IVisitaRepository, VisitaRepository>();
services.AddScoped<ISesionRepository, SesionRepository>();
services.AddScoped<ISocioRepository, SocioRepository>();
services.AddScoped<IProblematicoRepository, ProblematicoRepository>();

// UseCases
services.AddScoped<GetTodosSociosUseCase>();
services.AddScoped<ObtenerCumpleañerosUseCase>();
services.AddScoped<GetSocioUseCase>();
services.AddScoped<CrearProblematicoUseCase>();
services.AddScoped<ObtenerProblematicoPorIdUseCase>();
services.AddScoped<ActualizarProblematicoUseCase>();
services.AddScoped<EliminarProblematicoUseCase>();
services.AddScoped<FiltrarProblematicoPorTipoUseCase>();
services.AddScoped<CrearUsuarioUseCase>();
services.AddScoped<LoginUsuarioUseCase>();


builder.Host.UseSerilog();

var app = builder.Build();

// Middlewares
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<ExpiracionSesionApiMiddleware>();

// JWT: Validar token antes de acceder a claims
app.UseAuthentication();
app.UseAuthorization();

// Acceder al claim NameIdentifier (ya validado por el token)
app.UseMiddleware<UsuarioApiMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    builder.WebHost.UseUrls(configuration.GetSection("Dominio").Get<Dominio>().Produccion);
}

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();



app.Run();