using System.Collections.Generic;
using System.Threading.Tasks;
using RulesValidatorApi.Service.Domains.Request;
using RulesValidatorApi.Service.Domains.Response;
using RulesValidatorApi.Service.v1.Domains.Response;

namespace RulesValidatorApi.Service.v1.Services
{
    public interface IPostService
    {
        Task<IEnumerable<CsvValidationErrorResponse>> PostValidateAsync(CsvConfigurationForValidation csvConfigurationForValidation);
        Task<IEnumerable<CsvRulesResponse>> GetAllCsvRulesAsync();
    }
}