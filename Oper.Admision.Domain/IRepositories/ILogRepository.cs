
using Oper.Admision.Domain.Logs;

namespace Oper.Admision.Domain.IRepositories
{
    public interface ILogRepository
    {
        ICollection<Log> GetLogs(string salaIP,DateTime desde, DateTime hasta, string level);
    }
}
