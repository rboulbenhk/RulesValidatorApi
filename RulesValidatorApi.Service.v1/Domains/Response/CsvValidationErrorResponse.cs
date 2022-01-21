using System.Collections.Generic;

namespace RulesValidatorApi.Service.Domains.Response
{
    public class CsvValidationErrorResponse
    {
        public IEnumerable<ErrorDetail> Errors {get; set; } = new List<ErrorDetail>();
    }
}
