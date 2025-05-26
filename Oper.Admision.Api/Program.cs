using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using Oper.Admision.Domain.Logs;
using Oper.Admision.Api;
using Oper.Admision.Api.Configuracion;
using Oper.Admision.Api.Middlewares;
using Serilog;
using System.Text;
using Oper.Admision.Infrastructure;
using Oper.Admision.Infrastructure.Correo;
using Oper.Admision.Application;
using Microsoft.AspNetCore.Components.Forms;
using Oper.Admision.Application.UseCases.Usuarios.Crear;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Infrastructure.Repositories;
using Oper.Admision.Application.UseCases.Socios;
using Oper.Admision.Application.UseCases.Socios.GetSocio;
using AutoMapper;
using Oper.Admision.Api.UsesCases.Problematicos;
using Oper.Admision.Domain.Models;
using Oper.Admision.Application.UseCases.Problematico.CrearProblematico;
using Oper.Admision.Api.UseCases.Problematicos.ObtenerProblematicoID;
using Oper.Admision.Api.UsesCases.Problematicos.ObtenerProblematicoID;
using Oper.Admision.Application.UseCases.Problematico.ActualizarProblematico;
using Oper.Admision.Api.UseCases.Problematicos.ActualizarProblematico;
using Oper.Admision.Application.UseCases.Problematico.EliminarProblematico;

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IConfiguration configuration = builder.Configuration;
var services = builder.Services;

Serilog.Log.Logger = new LoggerConfiguration()
              .Enrich.FromLogContext()
              .WriteTo.Console()
              .ReadFrom.Configuration(configuration)
              .CreateLogger();

Serilog.Log.Information("Arranque servidor asp.net");



builder.Services.AddControllers()
      .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options =>
{

    options.AddPolicy(MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


services.Configure<IISServerOptions>(options => {
    options.MaxRequestBodySize = int.MaxValue;
});

services.Configure<KestrelServerOptions>(options => {
    options.Limits.MaxRequestBodySize = int.MaxValue;
});

services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = int.MaxValue; // if don't set default value is: 128 MB
    options.MultipartHeadersLengthLimit = int.MaxValue;
});

var mapperConfig = new MapperConfiguration(cfg =>
{
    // CrearProblematico
    CrearProblematicoMapping.Configure(cfg);
    // ObtenerProblematico
    ObtenerProblematicoMapping.Configure(cfg);
    //ActualizarProblematico
    ActualizarProblematicoMapping.Configure(cfg);
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = configuration["JWT:Issuer"],
                       ValidAudience = configuration["JWT:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
                       )
                   };

               });

services.Configure<Dominio>(configuration.GetSection("Dominio"));
services.Configure<ConfigCorreo>(configuration.GetSection("ConfigCorreo"));
services.AddScoped<IUsuarioApi, UsuarioApi>();
services.AddAutoMapper(typeof(EditarUsuarioMapping));
services.AddApiLayer(configuration);

services.AddInfrastructureLayer(configuration);
services.AddApplicationLayer();

services.AddControllers()
        //.AddNewtonsoftJson()
        ;
services.AddScoped<IVisitaRepository, VisitaRepository>();
services.AddScoped<ISesionRepository, SesionRepository>();
///////////////////////////////////////////////////////////////////////////
//Builders Agregados
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ISocioRepository, SocioRepository>();
builder.Services.AddScoped<ObtenerCumpleañerosUseCase>();
builder.Services.AddScoped<GetTodosSociosUseCase>();
builder.Services.AddScoped<IProblematicoRepository, ProblematicoRepository>();
builder.Services.AddScoped<CrearProblematicoUseCase>();
builder.Services.AddScoped<IProblematicoRepository, ProblematicoRepository>();
builder.Services.AddScoped<CrearProblematicoUseCase>();
builder.Services.AddScoped<ObtenerProblematicoPorIdUseCase>();
builder.Services.AddScoped<ActualizarProblematicoUseCase>();
builder.Services.AddScoped<CrearUsuarioUseCase>();
builder.Services.AddScoped<EliminarProblematicoUseCase>();
var app = builder.Build();


app.UseMiddleware(typeof(ErrorHandlerMiddleware));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    builder.WebHost.UseUrls(builder.Configuration.GetSection("Dominio").Get<Dominio>().Produccion);
}

app.UseDefaultFiles();
app.UseStaticFiles();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware(typeof(ExpiracionSesionApiMiddleware));

app.UseMiddleware(typeof(UsuarioApiMiddleware));



app.Run();
