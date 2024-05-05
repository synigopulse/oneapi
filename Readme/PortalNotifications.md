# PortalNotifications
## Steps


1. Create a REST endpoint for getting the notification settings for a specific user.
2. Create a REST endpoint for updating the notification settings for a specific user. this means you are responsible for maintaining state about wheter the user wants to see his notifications or not.
3. Update your swagger documentation for these endpoints.
4. Update your One API Setttings in CMS.
5. Create 2 new connections for getting and updating these settings.
6. Add these new connections to PortalSettings => External Notifications.
7. Inject notifications for users[^1].

[^1]: Make sure your Entra Application registration has access API access to the Your Digital Workplace Application so you can acquire a JWT token which allows you to make requests.

## Get NotificationSettings Endpoint
This endpoint returns the notification settings for a specific user. you can design the endpoint anyway you want to as long as it returns an array of notification settings, specific for the calling user.
### Response example
``` JSON
[
    {
        "notificationTypeId": "[Identifier-of-the-notification-type]",
        "title": "[The title of the notification setting]",
        "isActive": [true|false]
    }
]
```
(you can use the ```Synigo.OneApi.Model.Notifications.NotificationSettingModel``` class from the Nuget Package Synigo.OneApi.Model)
|Field|Type|Required|Description|
|---|---|---|---
|notificationTypeId|string|YES|When sending notification of a specific type, use the value here to correlate the notification with this setting.
|title|string|YES|The title or name of this notification setting. this title will be used for displaying this setting in the notification panel.
|isActive|boolean|YES|A boolean value indicating wether this notification is activated or not by the user.

## Update NotificationSettings Endpoint
This endpoint will be called when a user toggles his notification setting (and changes it to either active or inactive). It should be a POST REST endpoint accepting a single instance of the notification setting mentioned above. This endpoint should return an empty response with a 200 status. After updating, the portal will call the get endpoint to retrieve the modified settings.

## Injecting Notifications
You can use the implementation of the ```INotificationsClient``` of the Synigo.OneApi.Clients Nuget package to send portal notifications. This client expects an instance of a ```PortalNotificationModel``` class (see Synigo.OneApi.Model) and it will send the notification to the Synigo Pulse platform.

``` CSharp
       var notification = new Synigo.OneApi.Model.Notifications.PortalNotificationModel
       {
           Action = Synigo.OneApi.Model.Notifications.NotificationActionEnum.Created,
           Title = new Dictionary<string, string>{
               { "nl-NL" , "test" },
               { "en-US" , "test" }
           },
           Description = new Dictionary<string, string>{
               { "nl-NL" , "test Description" },
               { "en-US" , "test Description" }
           },
           Individuals = ["someone@your-org.com"],
           NotificationTypeIdentifier = "[Identifier-of-the-notification-type]",

       };
```
|Field|Type|Required|Description|
|---|---|---|---
|Action|NotificationActionEnum|YES|What action should the portal take for this notification: **Created:** This is a new notification and it should be shown asap. **Updated:** This is to touch an existing notifation and bring it into focus again. **Deleted** Remove this notification from the system. Note: Synigo Pulse will delete old messages automatically. 
|Title|Dictionary<string,string>|YES|The title of this notification. The Keys of the dictionary should be of the identifier of the language (either nl-NL, en-US, de-DE, fr-FR, or dk-DK). 
|Description|Dictionary<string,string>|YES|The description of this notification. The Keys of the dictionary should be of the identifier of the language (either nl-NL, en-US, de-DE, fr-FR, or dk-DK). 
|NotificationTypeIdentifier|string|YES|What type of notification is this. This field should correspondent with the ```NotificationTypeId``` of the NotificationSetting 
|Individuals|string[]|NO|Send this message to one or more people in your organization.
|Groups|string[]|NO|Send this message to one or more Entra Groups in your organization. *(note: either Individuals or Groups) is expected*
|ImageUrl|string|NO|Add a nice image to the notification. If no ImageUrl is provided. We will show a default image.
|Url|string|NO|If you want to add an action after clicking the notification. Use this url to route the user.




