# Adaptive Cards

## Introduction
Adaptive cards are a way of displaying information across different platforms and devices. They are designed to be easily integrated into applications and services, and can adapt to different screen sizes and user interfaces. Adaptive cards are particularly useful for displaying data in a visually appealing and interactive way. At Synigo We have incorporated adaptive cards into our system to allow our users to create adaptive cards and display them in a wide variety of ways.

## Usage
Adaptive cards can be used for a wide range of purposes, including displaying notifications, presenting data, and collecting user input. Here are some examples of how adaptive cards can be used:  

1.  **Notifications:** Adaptive cards can be used to display notifications to users in a visually appealing way, whether it's a simple message or a more complex alert with interactive elements.  
    
2.  **Data presentation:** Adaptive cards are great for presenting data such as news articles, weather forecasts, and sports scores. They can be customized to include images, charts, and other visual elements to make the information more engaging.  
    
3.  **Forms:** Adaptive cards can be used to collect user input, such as for surveys, polls, or quizzes. They can include different types of input fields, such as text boxes, drop-down menus, and checkboxes.  
    
4.  **Messaging:** Adaptive cards can be used in messaging platforms such as Microsoft Teams or Slack to send rich, interactive messages to users. They can include buttons, images, and other elements to make the messages more engaging. 

## Adaptive cards in Synigo Pulse
### Presentation
In Synigo Pulse we wrapped adaptive cards in a process and users are able to (re)use this process in a variety of ways:
- **Process Widget:** This widget renders an adaptive card in a single reusable widget
- **Processes Widget:** This widget displays processes as a list, here you can select one and it will be rendered in a dialog.
- **Process Menu Item:** This will render an Adaptive Card in our native app.
### Getting Data
A process uses connections to get and send data. It does not necessarily need connections, you could create a static card. If you want to have a visualisation of  data. You need to add an incoming connection. When displaying the card, this connection is used to get the data and add it to the $data context of the adaptive card. 
### Sending data
If you need to send data to a service, you need to define actions within your adaptive card. These action needs to have **verb** which we use to bind an outgoing connection. 

```json
{
	"type": "ActionSet",
	"actions": [
	{
		"type": "Action.Execute",
		"title": "Submit",
		"verb": "connection-submitdata"
	}]
}
```
(The sample above will ask you to add a connection for the connection-submitdata verb)

### connection types
Within our platform you can define two types of connections:
- **HTTP connection:** this is a simple HTTP connection, you can configure this to be a GET, POST, PUT,.. connection, with optional headers and a body and what not.
- **One API connection:** This is a connection which is configured in your main portal settings and is generated using the accompanied Open API Specification, and OAuth Authentication.

The figure below is a representation of the adaptive cards in Synigo Pulse.
![enter image description here](https://github.com/synigopulse/oneapi/blob/main/Readme/adaptivecards.png)



## How will this work
The diagram gives an overview about how this process will work: The user does something so that the portal or app needs to render a card. If there's an input connection defined, it will call this connection and get the data. The user can then manipulate this data and execute an action to send the manipulated data. Based on the response, the portal or app will behave in a certain way.

```mermaid
sequenceDiagram
User ->> Portal/App: Render an Adaptice Card

Portal/App ->> Your Connection: Get Input data
User ->> Portal/App: Change some data
User ->> Portal/App: Execute Action
Portal/App ->> Your Connection: Send data
Your Connection -->> Portal: Give a specific response

```
## Handling the response of the service
