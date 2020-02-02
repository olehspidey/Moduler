using System.Threading.Tasks;

namespace Moduler.Example.Services.Abstraction
{
    public interface IMessageService
    {
        Task<bool> SendAsync(string message);
    }
}