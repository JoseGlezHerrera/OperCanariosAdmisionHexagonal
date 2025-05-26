using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Oper.Admision.Domain;
using Oper.Admision.Domain.Correo;
using Oper.Admision.Domain.IRepositories;
using Oper.Admision.Domain.Tools;
using Oper.Admision.Infrastructure.Correo;

namespace Oper.Admision.Infrastructure
{
    public static class GestionServiceExtension
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GestionContext>(options => options.UseMySql(configuration["ConnectionStrings:CanalEtico"], new MySqlServerVersion(new Version(5, 7, 11))));

            services.AddScoped<IGestionUOW, GestionUOW>();

            services.AddScoped<IRolRepository, Infrastructure.Repositories.RolRepository>();
            services.AddScoped<IUsuarioRepository, Infrastructure.Repositories.UsuarioRepository>();

            services.AddScoped<Oper.Admision.Domain.IRepositories.ILogRepository, Infrastructure.Logs.LogRepository>();
            

            services.AddScoped<IImagenHelper, Infrastructure.Tools.ImagenHelper>();


            services.AddScoped<IGestionCorreo, GestionCorreo>(service =>
            {
                var param = service.GetRequiredService<IOptions<ConfigCorreo>>();
                return new GestionCorreo(param.Value);
            });
        }
    }
}
