namespace RulesValidatorApi.Application.Services;

public class PostService : IPostService
{
    private readonly IOptionsMonitor<List<RuleSetOptions>> _ruleSet;    
    private readonly ILogger<PostService> _logger = default!;
    private int? _maxNumberOfErrorsToReturn;

    public PostService(IOptionsMonitor<List<RuleSetOptions>> ruleSet,
    IOptionsMonitor<MaxNumberOfResponseOptions> maxNumberOfResponseOptions,
    ILogger<PostService> logger)
    {
        _ruleSet = ruleSet!;
        _logger = logger!;
        _maxNumberOfErrorsToReturn = SetMaxNumberOfErrorsFromConfiguration(maxNumberOfResponseOptions);
    }

    private int? SetMaxNumberOfErrorsFromConfiguration(IOptionsMonitor<MaxNumberOfResponseOptions> maxNumberOfResponseOptions)
    {
        var innerMaxNumberOfResponse = maxNumberOfResponseOptions.CurrentValue.Value;
        _logger.MaxNumberOfResponse(innerMaxNumberOfResponse);
        return innerMaxNumberOfResponse;
    }
    private List<RuleSetOptions> SetRuleSetFromConfiguration(IOptionsMonitor<List<RuleSetOptions>> ruleSet)
    {
        var ruleSetValues = ruleSet.CurrentValue;
        _logger.RuleSetValues(Utf8Json.JsonSerializer.ToJsonString(ruleSetValues));
        return ruleSetValues;
    }

    public async Task<IEnumerable<CsvValidationErrorResponse>> PostValidateAsync(CsvConfigurationForValidation csvConfigurationForValidation)
    {
        _logger.StartPostValidateAsync();
        using var _ = _logger.DebugTimedOperation(nameof(PostValidateAsync));
        //TODO Retrieve the file
        //TODO Parse the file
        //TODO Apply the rules validation
        //TODO Stop when you have the max validation defined reached
        var innerMax = _maxNumberOfErrorsToReturn;

        _logger.EndPostValidateAsync();
        return await Task.FromResult(Enumerable.Empty<CsvValidationErrorResponse>());
    }

    public async Task<IEnumerable<CsvRulesResponse>> GetAllCsvRulesAsync()
    {
        return await Task.FromResult(_ruleSet.CurrentValue.Select(s => new CsvRulesResponse { RuleName = s.RuleName, Description = s.Description, PossibleArgumentValues = s.PossibleArgumentValues }));
    }
}
