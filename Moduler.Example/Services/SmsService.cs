using System.Diagnostics;
using System.Threading.Tasks;
using Moduler.Example.Services.Abstraction;

namespace Moduler.Example.Services
{
    public class SmsService : IMessageService
    {
        public Task<bool> SendAsync(string message)
        {
            Debug.WriteLine($"Sending message: {message}");

            return Task.FromResult(true);
        }
    }
}