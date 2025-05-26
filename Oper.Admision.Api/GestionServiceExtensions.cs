using Oper.Admision.Api.Seguridad;
using System.Reflection;

namespace Oper.Admision.Api
{
    public static class GestionServiceExtensions
    {
        public static void AddApiLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWT>(configuration.GetSection("JWT"));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
                
    }
}
