using System.Collections.Generic;

namespace RulesValidatorApi.Service.Domains.Response
{
    public class CsvValidationErrorResponse
    {
        public IList<ErrorDetail> Errors {get; set; } = new List<ErrorDetail>();
    }
}
