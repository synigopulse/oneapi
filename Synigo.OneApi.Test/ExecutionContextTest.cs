using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Synigo.OneApi.Providers.RequestValidators;
using Synigo.OneApi.Test.Mock;
using Synigo.OneApi.Core.Extensions;
using Synigo.OneApi.Interfaces.Model;

namespace Synigo.OneApi.Test
{
    [TestClass]
    public class ExecutionContextTest
    {
        [TestMethod]
        public void TestInitializeContextSucces()
        {
            var host = BuildHost();
            var executionContext = host.ExecutionContext;

            Assert.IsNotNull(executionContext);
            Assert.IsNotNull(executionContext.CacheProvider);
            Assert.IsNotNull(executionContext.ConfigurationProvider);
        }

        [TestMethod]
        public async Task TestRequestNoValidationSucces()
        {
            var host = BuildHost();
            var executionContext = host.ExecutionContext;
            var testMethod = new Func<string>(() => "This will work");
            var mockFunctionRequestExecutor = new MockFunctionRequestExecutor(executionContext, AuthorizationLevel.None, testMethod);
            var result = (await mockFunctionRequestExecutor.Run(new MockHttpRequest())) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode == 200);

            Assert.IsNotNull(result.Value);
            Assert.IsTrue(result.Value.ToString() == testMethod());
        }

        private MockFunctionsHostBuilder BuildHost()
        {
            var testConfig = new Dictionary<string, string>();

            var hostBuilder = new MockFunctionsHostBuilder();
            hostBuilder.AddOneApi()
                .AddCacheProvider((serviceProvider) => new MockCacheProvider())
                .AddConfigurationProvider((serviceProvider) => new MockConfigurationProvider(testConfig))
                .AddRequestValidationProvider((serviceprovider) => new NoneRequestValidationProvider())
                .AddExecutionContext();

            hostBuilder.FinishSetup();
            return hostBuilder;
        }
    }
}
