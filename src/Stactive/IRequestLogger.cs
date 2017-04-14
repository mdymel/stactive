using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Stactive
{
    public interface IRequestLogger
    {
        Task LogRequest(HttpContext context, long processingTime);
    }
}