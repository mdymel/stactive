using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Stactive.Loggers
{
    public interface IRequestLogger
    {
        Task LogRequest(HttpContext context, long processingTime);
    }
}