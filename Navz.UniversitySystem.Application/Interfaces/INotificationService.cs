using Navz.UniversitySystem.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
        Task SendAsync(Alert alert);
        Task SendAsync(Data data);
    }
}
