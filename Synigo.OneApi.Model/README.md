# Model
This section gives a brief description of our models and how they are used within your Synigo Pulse Portal.

## Notifications
Notifications can be used to indicate that a user has something noteworthy in a particular system, 
for example: *"You have **3** assigned tickets"* from your ticketing system. 

It is also possible to nudge a user,
for example: *"You've passed your very difficult exam — Well done!!"* or *"It's your birthday — get out there and celebrate!"*

```CSharp
    /// <summary>
    /// This class represents a notification which is shown in the portal.
    ///
    /// Example notifications can be: 
    /// 'You have 3 new messages.' or 'It's time to enter your expense report.'
    ///
    /// The formatting of the messages can be done in your CMS.
    /// </summary>
    public class NotificationModel
    {
        /// <summary>
        /// Gets or sets the url to navigate to when a user clicks on this notication.
        /// (optional)
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the count of this notification. 
	/// If you set the count to 0 and you choose the "Hide when empty" flag,
	/// the notification not being shown.
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets an extension object containing additional data for this item.
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }
```
Or JSON
``` json
{
  "count": 3, // The count of items for your notification.
  "url": "https://www.microsoft.com", // A link to the source of your notification.
  "ext": {} // An extension object to pass additional data.
}
```
### Notes
- You can set the title, subtitle and image of your notification in your CMS. The count can be injected anywhere in the title and/or subtitle by using a **{0}** placeholder.
- If you want to nudge someone, you can either set the count to **0** or **1** where 0 hides the notification (nudge) and 1 shows the notification.
### Possible extensions
|Key|Type|Description|
|--|--|--|
| **card** |object| Adaptive Card json. If this is passed, clicking the notification will result into opening this Adaptive Card. For more information about Adaptive Cards and the way we handle them, please visit our support center at https://start.synigopulse.info. Also look at https://www.adaptivecards.io for more information about Adaptive Cards.

## People
You can add a People endpoint to your API to show a group of people to a user of your portal. Examples of this can include:
- All of a student's teachers.
- All of a student's fellow students.
- All of a customer's client team.
- All new employee's starting this week.

See the model below. 
```CSharp
    /// <summary>
    /// This class represents a person which is shown in the portal.
    /// </summary>
    public class Person
    {        
        /// <summary>
        /// Gets or sets the primary e-mail address for this person.
        /// </summary>
        [JsonPropertyName("mail")]
        public string Mail { get; set; }

        /// <summary>
        /// Gets or sets the url of the official picture for this person.
        /// </summary>
        [JsonPropertyName("photoOfficial")]
        public string PhotoOfficial { get; set; }

        /// <summary>
        /// Gets or sets an extension object containing additional data for this person.
        /// </summary>
        [JsonPropertyName("ext")]
        public Dictionary<string, object> Ext { get; set; }
    }
```
Or JSON
```json
[
  {
    "mail": "frank@contoso.com",
    "photoOfficial": "https://graph.microsoft.com/v1.0/users/frank@contoso.com/photo/$value?resource=https://graph.microsoft.com",
    "ext": {
      "title": "CTO",
      "subTitle": "Also makes the cocktails",
      "groupBy": "Management"
    }
  },
  {
    "mail": "jimbo@contoso.com",
    "photoOfficial": "https://graph.microsoft.com/v1.0/users/jimbo@contoso.com/photo/$value?resource=https://graph.microsoft.com",
    "ext": {
      "groupBy": "Management"
    }
  }
]
```

### Notes
- If you have bearer authentication in place for your photoOfficial resource, you can add the ?resource=[resourcename] querystring parameter to the photoOfficial url. The portal tries to resolve and use the bearer token associated with this resource. 
### Possible values for ext(ension)
|Key|Type|Description|
|--|--|--|
| **title** |string| Optional value. If you want to override the default title of this person, you can add this extension value
| **subTitle** | string| Optional value. You can add an extra (or sub) title to this person
| **groupBy** |string| Optional value. If you want to apply grouping of people, set this value as the title and groupby value. 

Here's a small example...
![Example](https://wesynigopulselive.blob.core.windows.net/public/images/people.png)
