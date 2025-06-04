using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Oper.Admision.Api
{
    public interface IUsuarioApi
    {
        int UsuarioId { get; }
    }

    public class UsuarioApi : IUsuarioApi
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsuarioApi(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int UsuarioId
        {
            get
            {
                var claim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
                if (claim != null && int.TryParse(claim.Value, out int userId))
                {
                    return userId;
                }
                return 0;
            }
        }
    }
}