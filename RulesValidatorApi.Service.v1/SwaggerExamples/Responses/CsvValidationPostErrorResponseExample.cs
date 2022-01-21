using System.Collections.Generic;
using RulesValidatorApi.Service.v1.Contracts.V1.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace RulesValidatorApi.Service.v1.SwaggerExamples.Responses
{
    public class CsvValidationPostErrorResponseExample : IExamplesProvider<CsvValidationPostErrorResponse>
    {
        public CsvValidationPostErrorResponse GetExamples()
        {
            var error = new PostErrorDetail();
            error.Message = "Error Message output displayed after CSV validation";
            return new CsvValidationPostErrorResponse{Errors = new List<PostErrorDetail>{error}};
        }
    }
}