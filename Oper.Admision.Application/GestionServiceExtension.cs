using Microsoft.Extensions.DependencyInjection;
using Oper.Admision.Application.UseCases.Sesiones.CrearSesion;
using Oper.Admision.Application.UseCases.Socios.CrearSocio;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Infrastructure.Repositories;

namespace Oper.Admision.Application
{
    public static class GestionServiceExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
          //  services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());


            services.AddScoped<UseCases.Rol.GetTodos.GetTodosUseCase>();
            //services.AddScoped<UseCases.Rol.GetEnlaces.GetEnlacesUseCase>();
            services.AddScoped<UseCases.Usuarios.Login.LoginUsuarioUseCase>();
            services.AddScoped<UseCases.Socios.EditarSocio.EditarSocioUseCase>();
            services.AddScoped<UseCases.Usuarios.CambiarPassword.CambiarPasswordUsuarioUseCase>();
            services.AddScoped<UseCases.Usuarios.Crear.CrearUsuarioUseCase>();
            services.AddScoped<UseCases.Usuarios.Editar.EditarUsuarioUseCase>();
            services.AddScoped<UseCases.Usuarios.Eliminar.CambiarPasswordUsuarioUseCase>();
            services.AddScoped<UseCases.Usuarios.DarBajaAlta.DarBajaAltaUsuarioUseCase>();
            services.AddScoped<UseCases.Usuarios.Resetear.ResetearUsuarioUseCase>();
            services.AddScoped<UseCases.Usuarios.GetTodos.GetTodosUsuarioUseCase>(); 
            services.AddScoped<UseCases.Socios.GetSocio.GetSocioUseCase>();
            services.AddScoped<UseCases.Visitas.CrearVisita.CrearVisitaUseCase>();
            services.AddScoped<UseCases.Sesiones.GetSesion.GetSesionUseCase>();
            services.AddScoped<CrearSesionUseCase>();
            services.AddScoped<CrearSocioUseCase>();
            services.AddScoped<UseCases.Visitas.GetVisita.GetVisitaUseCase>();
            services.AddScoped<UseCases.Visitas.EliminarVisita.EliminarVisitaUseCase>();
            services.AddScoped<ISocioRepository, SocioRepository>();


        }
    }
}
