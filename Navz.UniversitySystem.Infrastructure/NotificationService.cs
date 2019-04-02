using Microsoft.AspNetCore.SignalR;
using Navz.UniversitySystem.Application.Hubs;
using Navz.UniversitySystem.Application.Interfaces;
using Navz.UniversitySystem.Application.Notifications.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Infrastructure
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<AlertHub, IAlertHub> _alertHubContext;
        private readonly IHubContext<DataHub, IDataHub> _dataHubContext;

        public NotificationService(
            IHubContext<AlertHub, IAlertHub> alertHubContext, 
            IHubContext<DataHub, IDataHub> dataHubContext)
        {
            _alertHubContext = alertHubContext;
            _dataHubContext = dataHubContext;
        }

        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }

        public Task SendAsync(Alert alert)
        {
            _alertHubContext.Clients.Users(alert.To.ToList()).ReceiveAlert(alert.Title, alert.Message);
            return Task.CompletedTask;
        }

        public Task SendAsync(Data data)
        {
            _dataHubContext.Clients.All.UpdateData(data.Name);
            return Task.CompletedTask;
        }
    }
}
