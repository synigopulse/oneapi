# Providers
This section gives a brief description about our providers and how you can use them in your API.
The following links will help you navigate this page.

1. [Provider Implementation](#implementation)
    - [Step 1: Inherit and implement the relevant classes and interfaces](#step-1-inherit-and-implement-the-relevant-classes-and-interfaces)
	- [Step 2: Add the product provider middleware](#step-2-add-the-product-provider-middleware)
	- [Step 3: Use the product provider in your controller(s)](#step-3-use-the-product-provider-in-your-controllers)
2. [Health Checks](#health-checks)

## Product providers
Product providers are providers which help you setup a connection between your portal and a given product without
the need to handle everything yourself. We setup all the boilerplate for you, so that you can focus on the important
details. Below is a table of the available product providers currently available and any future providers that we plan on adding:

|Product|
|---------------------------|
|Afas|
|Azure Ad (soon)|
|Visual Studio Online (soon)|
|Zoho (soon)|
|And much more..|

### Implementation
In order to use our product providers follow these steps:

#### Step 1 Inherit and implement the relevant classes and interfaces.

```CSharp
using Synigo.OneApi.Interfaces;
	
/// <summary>
/// This is the interface for your own Afas endpoint calls.
/// </summary>
public interface IMyAfasProvider : IAfasProvider
{
    // Add the api methods you want to implement here..
    // e.g: GetVacanciesAsync(int skip = 0, int take = 20)
    // or anything else you want to retrieve from the Afas API
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

#### Step 2 Add the product provider middleware.

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

#### Step 3 Use the product provider in your controllers

```CSharp
[Route("api/[controller]")]
[ApiController]
public class MyAfasController : OneApiController
{
    private readonly IMyAfasProvider _myAfasProvider;

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

### Health Checks
Any product provider created using the IProductProvider interface such as: AbstractProductProvider or IAfasProvider
will have to implement the health check functionality. These health checks are automatically added on runtime
to the IServiceCollection using the IHealthChecksBuilder as part of Dependency Injection. Adding the middleware 
for a product provider in the ConfigureCustomServices(OneApiBuilder builder) will automatically have add their 
health checks on runtime and can be accessed on the url: {baseurl}/health

The default implementation for the product provider health check looks as follows:

```CSharp
namespace Synigo.OneApi.Providers.Products
{
    /// <summary>
    /// An abstract implementation of a base product provider.
    /// </summary>
    public abstract class AbstractProductProvider : IProductProvider
    {
	
        ...
	
        // Should be overridden in child classes.
        public virtual Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Healthy($"No health check provided for type {GetType()}."));
        }
	
        ...
		
    }
}
```

Which results in the following JSON when performing a request on the health endpoint.

```json
{
  "status": "Healthy",
  "results": {
    "My Afas Health Check": {
      "status": "Healthy",
      "description": "No health check provided for type MyAfasProvider.",
      "tags": [],
      "data": {}
    }
  }
}

```

The health check behaviour is expected to be overriden. Below is an example of how
you can override the default behaviour:

```CSharp
public class MyAfasProvider : AbstractProductProvider, IMyAfasProvider
{
    public MyAfasProvider(IHttpClientFactory clientFactory) : base(clientFactory, "MyAfasClient")
    {
    }

    /// <summary>
    /// The health check implementaton for this product provider.
    /// </summary>
    public override Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var isHealthy = true;
	
        // ...
	
        if (isHealthy)
        {
            return Task.FromResult(HealthCheckResult.Healthy("A healthy result."));
        }
	
        return Task.FromResult(new HealthCheckResult(context.Registration.FailureStatus, "An unhealthy result."));
    }
	
    /// <summary>
    /// The unique name of this health check.
    /// </summary>
    public override string HealthCheckName => "My Afas Health Check";
	
    /// <summary>
    /// A collection of tags which can be used for filtering.
    /// </summary>
    public override IEnumerable<string> Tags => new string[]
    {
        "afas", "demo"
    };
	
    /// <summary>
    /// The default failure status when an Unhealthy result is given.
    /// </summary>
    public override HealthStatus DefaultFailureStatus => HealthStatus.Unhealthy;
}
```

Which results in the following json:

```json
{
  "status": "Healthy",
  "results": {
    "My Afas Health Check": {
      "status": "Healthy",
      "description": "A healthy result.",
      "tags": [
        "afas",
        "demo"
      ],
      "data": {}
    }
  }
}
```

For more examples check our demo page:
[TODO]
