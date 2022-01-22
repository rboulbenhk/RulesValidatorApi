using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RulesValidatorApi.Service.Domains.Request;
using RulesValidatorApi.Service.Domains.Response;
using RulesValidatorApi.Service.v1.Rules;

namespace RulesValidatorApi.Service.v1.Services
{
    public class PostService : IPostService
    {
        private readonly IOptionsMonitor<MaxNumberOfResponseOptions> _maxNumberOfResponseOptions;
        private readonly ILogger<PostService> _logger;
        private int? _maxNumberOfErrorsToReturn;
        
        
        public PostService(IOptionsMonitor<MaxNumberOfResponseOptions> maxNumberOfResponseOptions, ILogger<PostService> logger)
        {
            _maxNumberOfResponseOptions = maxNumberOfResponseOptions;
            _logger = logger;
            _maxNumberOfErrorsToReturn = SetMaxNumberOfErrorsFromConfiguration();
        }

        private int? SetMaxNumberOfErrorsFromConfiguration()
        {
            var innerMaxNumberOfResponse = _maxNumberOfResponseOptions.CurrentValue.MaxNumberOfResponse;
            _logger.LogDebug($"{nameof(MaxNumberOfResponseOptions.SectionName)} retrieved from settings = '{innerMaxNumberOfResponse}'");
            return innerMaxNumberOfResponse;
        }

        public async Task<IEnumerable<CsvValidationErrorResponse>> PostValidateAsync(CsvConfigurationForValidation csvConfigurationForValidation)
        {
            //TODO Retrieve the file
            //TODO Parse the file
            //TODO Apply the rules validation
            //TODO Stop when you have the max validation defined reached

            return await Task.FromResult(Enumerable.Empty<CsvValidationErrorResponse>());
        }
    }
}