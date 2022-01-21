using System.Collections.Generic;
using RulesValidatorApi.Service.v1.Contracts.V1.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace RulesValidatorApi.Service.v1.SwaggerExamples.Responses
{
    public class ErrorResponseExample : IExamplesProvider<ErrorResponse>
    {
        public ErrorResponse GetExamples()
        {
            var errorCode = new ErrorCode{ FieldName = "Invalid field name", Message= "Error message detail"};
            return new ErrorResponse
            {
                Errors = new List<ErrorCode>{errorCode}
            };
        }
    }
}