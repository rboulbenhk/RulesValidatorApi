using Microsoft.Extensions.Options;
using RulesValidatorApi.Service.v1.Rules;

namespace RulesValidatorApi.Service.v1.Services
{
    public class PostService : IPostService
    {
        private readonly IOptionsMonitor<List<RuleSetOptions>> _ruleSet;
        private readonly IOptionsMonitor<MaxNumberOfResponseOptions> _maxNumberOfResponseOptions;
        private readonly ILogger<PostService> _logger;
        private int? _maxNumberOfErrorsToReturn;
        
        
        public PostService(IOptionsMonitor<List<RuleSetOptions>> ruleSet,
        IOptionsMonitor<MaxNumberOfResponseOptions> maxNumberOfResponseOptions, 
        ILogger<PostService> logger)
        {
            _ruleSet = ruleSet;
            _logger = logger;
            _maxNumberOfErrorsToReturn = SetMaxNumberOfErrorsFromConfiguration(maxNumberOfResponseOptions);
        }

        private int? SetMaxNumberOfErrorsFromConfiguration(IOptionsMonitor<MaxNumberOfResponseOptions> maxNumberOfResponseOptions)
        {
            var innerMaxNumberOfResponse = maxNumberOfResponseOptions.CurrentValue.Value;
            _logger.LogDebug($"{nameof(MaxNumberOfResponseOptions.SectionName)} retrieved from settings = '{innerMaxNumberOfResponse}'");
            return innerMaxNumberOfResponse;
        }
        private List<RuleSetOptions> SetRuleSetFromConfiguration(IOptionsMonitor<List<RuleSetOptions>> ruleSet)
        {
            var ruleSetValues = ruleSet.CurrentValue;            
            _logger.LogDebug($"{nameof(RuleSetOptions.SectionName)} retrieved from settings'");
            return ruleSetValues;
        }

        public async Task<IEnumerable<CsvValidationErrorResponse>> PostValidateAsync(CsvConfigurationForValidation csvConfigurationForValidation)
        {
            //TODO Retrieve the file
            //TODO Parse the file
            //TODO Apply the rules validation
            //TODO Stop when you have the max validation defined reached

            return await Task.FromResult(Enumerable.Empty<CsvValidationErrorResponse>());
        }

        public async Task<IEnumerable<CsvRulesResponse>> GetAllCsvRulesAsync()
        {
            return await Task.FromResult(_ruleSet.CurrentValue.Select(s => new CsvRulesResponse{RuleName = s.RuleName, Description = s.Description, PossibleArgumentValues = s.PossibleArgumentValues}));
        }
    }
}