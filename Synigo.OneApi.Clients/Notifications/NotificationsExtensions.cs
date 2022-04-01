using Microsoft.Extensions.DependencyInjection;
using Synigo.OneApi.Core.WebApi;

namespace Synigo.OneApi.Clients.Notifications
{
    public static class NotificationsExtensions
    {
        public static OneApiBuilder UseNotificationsClient(this OneApiBuilder builder)
        {
            builder.Services.AddScoped<INotificationsClient, NotificationsClient>();
            return builder;
        }
    }
}
