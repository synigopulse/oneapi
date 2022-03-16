using Synigo.OneApi.Clients.Notifications.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Synigo.OneApi.Clients.Notifications
{
    public interface INotificationsClient
    {
        Task<HttpResponseMessage> SendNotification(NotificationSource notification);
    }
}
