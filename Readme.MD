# Coinage.Api

Coinage.Api is a .Net Core Api that exposes Api endpoints for adding coins to a jar with specified volume.

## Built Using

* [.Net 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.404-windows-x64-installer)
* [.Net 5 SDK](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.101-windows-x64-installer)

### Prerequisites

* Visual Studio 2019
* IIS / IISExpress
* No Nuget packages required (System.Text.Json used over Newtonsoft)

### Getting it running
Just clone and run, I have prepared an index view for playing around with the endpoints.

### Key Points
* You can find the controlled data inside the Coinage.Api.Data Folder. Here you can define the Volume of the jar in any unit, with the ratio to cubic mm. You will also find the data of all coin dimensions.
* Data Services are injected as singletons during program startup.
* Coin Jar and Coin Factory are injected as singletons during program startup.
* IMemoryCache used to persist coin jar contents.
* For reference of the dimensions used, please see wiki [here](https://en.wikipedia.org/wiki/Coins_of_the_United_States_dollar).