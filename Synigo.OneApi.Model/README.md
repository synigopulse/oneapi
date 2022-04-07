# Model
this section gives a brief description of our models and how they are used within your Synigo Pulse Portal.

## Notifications
Notifications can be used to indicate that a user has something noteworthy in a particular system, for example *You have **3** assigned tickets* from your ticketing system. 

It is also possible to nudge a user, for example *"You've passed your very difficult exam — Well done!!"* or *"It's your birthday — get out there and celebrate!"*

``` json
{
   "count": 3, //the count of items for your notification
   "url": 'https://www.microsoft.com', //A link to the source of your notification
   "ext": {} //An extension object to pass additional data
}
```
### Notes
- In your CMS, you can set the title, subtitle and image of your notification. The count can be injected anywhere in the title and or subtitle by using a **{0}** placeholder.
- If you want to nudge someone, you can either set the count to **0** or **1** where 0 hides the notification (nudge) and 1 shows the notification.
- 
