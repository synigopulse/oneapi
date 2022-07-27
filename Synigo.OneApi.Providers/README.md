# Providers
This section gives a brief description about our providers and how you can use them in your API.

## Product providers
Product providers are providers which help you setup a connection between your portal and a given product without
the need to handle everything yourself. We setup all the boilerplate for you, so that you can focus on the important
details. Below is a table of the available product providers currently available and any future providers that we plan on adding:

|Product|
|--------------------------|
|Afas|
|Azure Ad (soon)|
|Visual Stuio Online (soon)|
|Zoho (soon)|
|And much more..|

### Implementation
In order to use our product providers follow these steps:

#### Step 1: Inherit and implement the relevant classes and interfaces.

```CSharp
using Synigo.OneApi.Interfaces;
	
/// <summary>
/// This is the interface for your own Afas endpoint calls.
/// </summary>
public interface IMyAfasProvider : IAfasProvider
{
    // Add the api methods you want to implement here..
    // e.g: GetVacanciesAsync(int skip = 0, int take = 20)
    // or whatever else you want to retrieve from the Afas API
}
```

```CSharp
using Synigo.OneApi.Interfaces;
using Synigo.OneApi.Providers.Products;
using System.Net.Http;
	
/// <summary>
/// Extend your provider class using the AbstractProductProvider base class
/// and implement from the IAfasProvider interface.
/// </summary>
public class MyAfasProvider : AbstractProductProvider, IMyAfasProvider
{
    /// <summary>
    /// This class is injected as part of Dependency Injection pipeline into the IServiceCollection,
    /// which means the constructor has to look as follows. Note that the name of the HTTP client
    /// is passed to the base explicitly and has to be unique per provider.
    /// </summary>
    public MyAfasProvider(IHttpClientFactory clientFactory) : base(clientFactory, "MyAfasClient")
    {
    }
		
		
    // Implement the api methods defined in your interface here..
    // e.g: GetVacanciesAsync(int skip = 0, int take = 20)
		

    /// <summary>
    /// For more information about the Health Checks refer to the 'Health Check' section of the documentation.
    /// </summary>
    public override string HealthCheckName => "My Afas Health Check";
}
```

#### Step 2: Add the product provider middleware.

```CSharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Synigo.OneApi.Core.WebApi;
using Synigo.OneApi.Providers.Extensions; // Middleware taken from here

public class Startup : BaseStartup
{

    ...

    // Here you can configure custom services using the OneApiBuilder. The custom
    // services are injected into the IServiceCollection of the BaseStartup during runtime.
    protected override void ConfigureCustomServices(OneApiBuilder builder)
    {
        builder.Services.AddAfasProvider<IMyAfasProvider, MyAfasProvider>(options =>
        {
            options.AuthToken = "PLAIN_TEXT_AFAS_TOKEN"; // The token is encoded according to what Afas expects.
            options.HttpClientName = "MyAfasClient"; // This adds the HTTP client to the IHttpClientFactory which is used in MyAfasProvider.
            options.BaseAddress = "AFAS_END_POINT_BASE_URL"; // The endpoint url for this specific provider e.g: https://{userid}.rest.afas.online
        });
    }
	
    ...
	
}
```

#### Step 3: Use the product provider in your controller(s)

```CSharp
[Route("api/[controller]")]
[ApiController]
public class MyAfasController : OneApiController
{
    private readonly IMyAfasProvider? _myAfasProvider;

    public MyAfasController(IExecutionContext context, IMyAfasProvider myAfasProvider) 
        : base(context)
    {
        _myAfasProvider = myAfasProvider;
    }

    ...

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // Here you can call the methods specified in IMyAfasProvider
        // and return those results...
			
        // e.g: var result = await _myAfasProvider.GetVacanciesAsync();

        return new Ok();
    }
		
    ...
    
}
```

For more examples check our demo page:
[TODO]
