using System.Collections.Generic;

namespace RulesValidatorApi.Service.v1.Contracts.V1.Responses
{
    public class CsvValidationPostErrorResponse
    {
        public IEnumerable<PostErrorDetail>? Errors {get; set;}
    }
}