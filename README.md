net-bugsnag
===========

.NET Bugsnag is a notifier library for http://bugsnag.com.  It includes support for logging Events, Exceptions, Stacktrace information, and meta information.  

For more information about the examples below, you can visit https://bugsnag.com/docs/notifier-api for a full reference.

Quick Start
-----------

Add a reference to Bugsnag.Library.dll 

Next, you will need to provide .NET BugSnag with your API key.  There are 2 ways to do this:  Choose one.

a) Add an AppSetting with your api key to your config (this is the easiest way)

	<appSettings>
		<add key="apiKey" value="[your api key here]" />
	</appSettings>
