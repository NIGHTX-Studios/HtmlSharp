# HtmlSharp
An API to connect C# and JavaScript.

# Information
> Current Version: V1
> 
> Release Date: 19th of august 2022
> 
> Developers: [David Gerson](https://github.com/pogrammerX)

# Donations
## Donations are greatly appreciated and go right back into Development!
<a href="https://www.paypal.com/donate/?hosted_button_id=J73E95G4JUWPG">Donate</a>

# How to import
## Use the example Project
Download the example project from the releases and open it in Visual Studio 2019.
## Start from scratch
Create a new C# Project in Visual Studio 2019.

Right Click your Project and Navigate to Add -> Add COM Reference.

Inside of the now opened window, click on Browse, then click on the Browse button.

Select the "HtmlSharp.dll" file.

Click Okay -> Okay.

Now in your Programs.cs file or the file were you want to use HtmlSharp add the following lines:

```
using NIGHTX.HtmlSharp;
using static NIGHTX.HtmlSharp.HtmlSharpManager;
```

Now you are done importing.

# Usage
Copy this code and then well speak about it:

C#
```
RegisterCallback("alrt", (object sender, WebClientEA a) =>
{
    a.WebClient.Alert(a.Arguments[0]);
});
StartHtmlSharp("./Web");
```

HTML
```
<button style="border-radius: 5px; border-style: none; background: lime; color: white; font-size: 50px; width: 250px; height: 80px; cursor: pointer;" onclick="PerformCallback('alrt', 'Hello, HtmlSharp World!')"> Test </button>
```

Lets talk about the C# Code,

The Register Callback Fucntion takes in two arguments, one the name of the callback, and the eventhandler, the Event Handler uses the WebClientEA class as Event Args

This class contains two Variables:

Arguments - The Arguments sent with the callback.

WebClient - The WebClient.

We will use ``` a.WebClient.Alert(a.Arguments[0])``` to alert the first argument parsed.

Now to the Html Code,

We got as button with some designing, but mainly we got a "onclick" event with the code ```PerformCallback('alrt', 'Hello, HtmlSharp World!')```





<img src="./WarnJSASBSC.svg">

Now remember the Callback name?

Thats right it was "alrt" so we Perform the callback with the name "alrt", with the argument "Hello, HtmlSharp World!"!

What will this do?

When you click on the button it will alert "Hello, HtmlSharp World!"!

If you got any issues or question feel free to dm me on discord: pogrammerX#1167

Till' then, Happy coding!
