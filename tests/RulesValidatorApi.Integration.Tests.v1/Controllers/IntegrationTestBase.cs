using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using Newtonsoft.Json;
using RulesValidatorApi.Contract.Contracts.V1.Requests;
using RulesValidatorApi.Contract.Contracts.V1;
using RulesValidatorApi.Contract.Contracts.V1.Responses;

namespace RulesValidatorApi.Integration.Tests.v1.Controllers
{
    public class IntegrationTestBase
    {
        protected HttpClient? MyClient;

        [SetUp]
        public void SetUp()
        {
            var factory = new WebApplicationFactory<Startup>();
            MyClient = factory.CreateClient();
        }

        protected async Task<CsvValidationPostErrorResponse> ValidateAsync(CsvValidationPostRequest request)
        {
            var response = await MyClient.PostAsJsonAsync(ApiRoutes.PostCvsController.ValidateAsync, request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var csvValidationPostErrorMessage = JsonConvert.DeserializeObject<CsvValidationPostErrorResponse>(responseContent);
            return csvValidationPostErrorMessage!;
        }

        protected CsvValidationPostRequest MyCsvValidationPostRequest()
        {
            var request = new CsvValidationPostRequest();
            request.FilePath = "MyTestFile.csv";
            var myPostRuleSetRequest = new PostRuleSetRequest();
            myPostRuleSetRequest.ColumnId = 1;
            myPostRuleSetRequest.RuleName = "Empty";
            return request;
        }
    }
}