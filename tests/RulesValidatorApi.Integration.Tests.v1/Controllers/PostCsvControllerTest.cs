using System.Threading.Tasks;
using NUnit.Framework;

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