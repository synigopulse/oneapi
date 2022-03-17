using Synigo.OneApi.Model.Notifications;
using System.Net.Http;
using System.Threading.Tasks;

namespace Synigo.OneApi.Clients.Notifications
{
    public interface INotificationsClient
    {
        Task<HttpResponseMessage> SendNotification(PortalNotificationModel notification);

        Task<HttpResponseMessage> SendPushNotification(PushNotificationModel pushNotification);
    }
}
