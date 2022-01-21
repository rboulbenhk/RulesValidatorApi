using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RulesValidatorApi.Service.Domains.Request;
using RulesValidatorApi.Service.Domains.Response;

namespace RulesValidatorApi.Service.v1.Services
{
    public class PostService : IPostService
    {
        public PostService()
        {
            
        }
        public async Task<IEnumerable<CsvValidationErrorResponse>> PostValidateAsync(CsvConfigurationForValidation csvConfigurationForValidation)
        {
            return await Task.FromResult(Enumerable.Empty<CsvValidationErrorResponse>());
        }
    }
}