using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Synigo.OneApi.Clients.Notifications;
using Synigo.OneApi.Model.Notifications;
using System.Collections.Generic;

namespace Synigo.DemoApi
{
    public class SendPushNotification
    {
        private readonly TokenProvider _tokenProvider;
        private readonly INotificationsClient _notificationsClient;

        public SendPushNotification(TokenProvider tokenProvider, INotificationsClient notificationsClient) {
            _tokenProvider = tokenProvider;
            _notificationsClient = notificationsClient;
        }

        [FunctionName("SendPushNotification")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var token = await _tokenProvider.GetSynigoApplicationTokenAsync();
            var dummyModel = CreateDummyModel();
            var result = await _notificationsClient.SendNotification(dummyModel, token);
            var resultData = await result.Content.ReadAsStringAsync();

            var jsonResult = new ContentResult();
            jsonResult.Content = resultData;
            jsonResult.ContentType = "application/json";

            return jsonResult;
        }

        private PortalNotificationModel CreateDummyModel() {
            var now = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            return new PortalNotificationModel
            {
                Action = NotificationActionEnum.Created,
                Title = new Dictionary<string, string> {
                    { "nl-NL",$"Test notificatie"},
                    { "en-US",$"Test notification"}
                },
                Description = new Dictionary<string, string> {
                    { "nl-NL",$"Deze notificatie is om {now} gemaakt"},
                    { "en-US",$"This notification is created at {now}"}
                },
                Individuals = new List<string> { "[someone@theirupn.com]"},
                ImageUrl = "https://img.icons8.com/external-filled-outline-lima-studio/64/external-test-nuclear-energy-filled-outline-lima-studio.png",
                NotificationTypeIdentifier = "",
                Url = "https://www.google.com"
            };
        }
    }
}

