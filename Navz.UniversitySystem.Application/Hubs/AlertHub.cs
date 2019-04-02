using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Hubs
{
    public class AlertHub : Hub<IAlertHub>
    {
        public async Task SendAlert(string title, string message)
        {
            await Clients.User(Context.User.Claims.Where(u => u.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value).ReceiveAlert(title, message);
        }
    }

    public interface IAlertHub
    {
        Task ReceiveAlert(string title, string message);
    }
}
