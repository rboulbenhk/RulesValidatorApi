using System.Collections.Generic;
using System.Threading.Tasks;
using RulesValidatorApi.Service.Domains.Request;
using RulesValidatorApi.Service.Domains.Response;

namespace RulesValidatorApi.Service.v1.Services
{
    public interface IPostService
    {
        Task<IEnumerable<CsvValidationErrorResponse>> PostValidateAsync(CsvConfigurationForValidation csvConfigurationForValidation);
    }
}