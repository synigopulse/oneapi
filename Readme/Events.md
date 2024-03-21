# Events

## Introduction
The portal allows you to easily display events retrieved from a (custom) API. This section will cover the basics to create your endpoint for use in the portal.

## Sample
The portal requires the output data to be a [OdataContainer](https://github.com/synigopulse/oneapi/blob/main/Synigo.OneApi.Model/OdataContainer.cs), see example below.

```csharp
using Microsoft.Graph;
using Synigo.OneApi.Model;
// using Synigo.OneApi.Model.Widgets;

...

public async Task<HttpResponseData> GetEvents() {
  List<Event> events = ...; // Retrieve all relevant events from the MS Graph
  // List<EventModel> events = ...; // if you're using the Synigo EventModel instead of Microsoft.Graph.Event

  // Convert the events to a model the portal can understand.
  // OdataContainer<List<EventModel>> container = new OdataContainer<List<EventModel>> // if you're using the Synigo EventModel instead of Microsoft.Graph.Event
  OdataContainer<List<Event>> container = new OdataContainer<List<Event>>
  {
      Type = "#graph.microsoft.com/event", // this indicates that the events are MS Graph events
      // Type = EventModel.SynigoType, // if you're using the Synigo EventModel instead of Microsoft.Graph.Event
      Value = events
  };

  string json = JsonSerializer.Serialize(container);
  await response.WriteStringAsync(json);

  return response;

}

...
```

This results in the following json:

Note: the following sample does not cover all properties from the Event object.

```json
{
	"@odata.type": "#graph.microsoft.com/event", // this indicates that the events are MS Graph events
	"value": [
		{
			"id": "00000000-0000-0000-0000-000000000000",
			"createdDateTime": "2024-03-21T10:41:21.4490776Z",
			"lastModifiedDateTime": "2024-03-21T10:41:21.4490963Z",
			"changeKey": null,
			"categories": null,
			"originalStartTimeZone": "W. Europe Standard Time",
			"originalEndTimeZone": "W. Europe Standard Time",
			"iCalUId": null,
			"reminderMinutesBeforeStart": 0,
			"hasAttachments": false,
			"subject": null,
			"bodyPreview": null,
			"importance": null,
			"sensitivity": "normal",
			"isAllDay": true,
			"isCancelled": false,
			"isOrganizer": false,
			"responseRequested": false,
			"seriesMasterId": null,
			"showAs": "busy",
			"type": null,
			"webLink": null,
			"onlineMeetingUrl": null,
			"responseStatus": null,
			"body": {
				"contentType": "Text",
				"content": null
			},
			"start": null,
			"end": null,
			"location": {
				"displayName": null
			},
			"recurrence": null,
			"attendees": null,
			"calendar": {
				"id": "sample",
				"isSharedWithMe": false,
				"isRemovable": false,
				"name": "sample",
				"color": 5,
				"owner": null
			},
			"ext": null
		}
	]
}
```
