using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using RulesValidatorApi.Service.Contracts.V1;

namespace RulesValidatorApi.Integration.Tests.v1.Controllers;

public class PostCsvControllerTest : IntegrationTestBase
{
    private HttpClient? _client;    

    [Test]
    public async Task Test1()
    {
        var response = await _client!.PostAsync(ApiRoutes.PostCvsController.Post,null);
    }
}