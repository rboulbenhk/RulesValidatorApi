using System.Collections.Generic;
using System.Linq;

namespace RulesValidatorApi.Service.v1.Contracts.V1.Responses
{
    public class CsvValidationPostErrorResponse
    {
        public string Message { get; set; } = string.Empty;
        public IEnumerable<string> Errors {get; set;} = Enumerable.Empty<string>();
    }
}