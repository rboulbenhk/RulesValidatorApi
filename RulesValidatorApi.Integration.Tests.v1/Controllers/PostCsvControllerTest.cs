using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using RulesValidatorApi.Service.Contracts.V1;
using RulesValidatorApi.Service.v1.Contracts.V1.Requests;

namespace RulesValidatorApi.Integration.Tests.v1.Controllers;

public class PostCsvControllerTest : IntegrationTestBase
{
    [Test]
    public async Task Test1()
    {
        var request = MyCsvValidationPostRequest();
        await ValidateAsync(request);
    }
}