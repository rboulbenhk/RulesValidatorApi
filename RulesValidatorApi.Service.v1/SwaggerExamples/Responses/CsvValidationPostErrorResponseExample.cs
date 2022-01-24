using RulesValidatorApi.Service.v1.Contracts.V1.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace RulesValidatorApi.Service.v1.SwaggerExamples.Responses
{
    public class CsvValidationPostErrorResponseExample : IExamplesProvider<CsvValidationPostErrorResponse>
    {
        public CsvValidationPostErrorResponse GetExamples()
        {
            return new CsvValidationPostErrorResponse{ Message = "Information message after CSV validaion", Errors = new string[]{"List of errors after the validation"}};
        }
    }
}