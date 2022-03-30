using Synigo.OneApi.Model.Notifications;
using System.Net.Http;
using System.Threading.Tasks;

namespace Synigo.OneApi.Clients.Notifications
{
    public interface INotificationsClient
    {
        Task<HttpResponseMessage> SendNotification(PortalNotificationModel notification, string token);

        Task<HttpResponseMessage> SendPushNotification(PushNotificationModel pushNotification, string token);
    }
}
