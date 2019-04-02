using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Hubs
{
    public class DataHub : Hub<IDataHub>
    {
        public async Task SendData(string name)
        {
            await Clients.All.UpdateData(name);
        }
    }

    public interface IDataHub
    {
        Task UpdateData(string name);
    }
}
