using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace RulesValidatorApi.Integration.Tests.v1.Controllers
{
    public class IntegrationTestBase
    {
        protected HttpClient MyClient;
        
        [SetUp]
        public void SetUp()
        {
            var factory = new WebApplicationFactory<Startup>();
            MyClient = factory.CreateClient();
        }
    }
}