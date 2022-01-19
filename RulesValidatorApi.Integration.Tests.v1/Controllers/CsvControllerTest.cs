using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace RulesValidatorApi.Integration.Tests.v1.Controllers;

public class CsvControllerTest
{
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        var factory = new WebApplicationFactory<Startup>();
        _client = factory.CreateClient();
    }

    [Test]
    public void Test1()
    {
        
        Assert.Pass();
    }
}