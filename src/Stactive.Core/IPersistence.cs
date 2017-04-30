using System.Threading.Tasks;
using Stactive.Core.Models;

namespace Stactive.Core
{
    public interface IPersistence
    {
        Task SaveRequestLog(RequestLog log);
    }
}