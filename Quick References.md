# Quick References

# Functions
| Class  | Function | Description | Syntax |
| ------------- | ------------- | ------------- | ------------- |
| HtmlSharpManager | StartHtmlSharp | Starts the Html Sharp Server | HtmlSharpManager.StartHtmlSharp("location", port (default 80))
| HtmlSharpManager | RegisterCallback | Register a Callback | HtmlSharpManager.RegisterCallback("name", EventHandler<WebClientEA> eventHandler)
| WebClient | Redirect | Redirects a User to the specific URL. | WebClient.Redirect("https://google.com");
| WebClient | Alert | Show an Alert Box | WebClient.Alert("Text");
| WebClient | WriteSuccess | Writes Success for non-data-returning callbacks | WebClient.WriteSuccess();
| WebClient | WriteFailure | Writes Failure for non-data-returning callbacks | WebClient.WriteSuccess();
| WebClient | SendData | Sends data, as the result of the callback | WebClient.SenData("data");
| WebClient | Popup | Opens an Popup | WebClient.Popup(new Link("https://google.com"), "title", Width, Height);
  
# Variables
| Class  | Variable | Description |
| ------------- | ------------- | ------------- |
| WebClientEA | WebClient | The WebClient class for the Browser Client.
| WebClientEA | Arguments | All the Arguments (in JavaScript split the references by an ";")
