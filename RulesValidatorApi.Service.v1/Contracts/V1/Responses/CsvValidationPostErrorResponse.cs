using System.Collections.Generic;
using System.Linq;

namespace RulesValidatorApi.Service.v1.Contracts.V1.Responses
{
    public class CsvValidationPostErrorResponse
    {
        public IEnumerable<PostErrorDetail> Errors {get; set;} = Enumerable.Empty<PostErrorDetail>();
    }
}