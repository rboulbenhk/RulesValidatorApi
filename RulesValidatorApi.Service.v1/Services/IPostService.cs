using System.Collections.Generic;
using RulesValidatorApi.Service.Domains.Response;

namespace RulesValidatorApi.Service.v1.Services
{
    public interface IPostService
    {
        IEnumerable<CsvValidationErrorResponse> PostValidate();
    }
}