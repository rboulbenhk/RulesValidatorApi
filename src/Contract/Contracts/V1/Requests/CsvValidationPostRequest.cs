namespace RulesValidatorApi.Contract.Contracts.V1.Requests;

public class CsvValidationPostRequest
{
    public string FilePath { get; set; } = string.Empty;
    public IEnumerable<PostRuleSetRequest> RuleSet { get; set; } = Enumerable.Empty<PostRuleSetRequest>();
}