namespace RulesValidatorApi.Contract.Contracts.V1.Requests;

public class PostRuleSetRequest
{
    public int ColumnId { get; set; }
    public string RuleName { get; set; } = string.Empty;
    public IEnumerable<string> ArgumentValues { get; set; } = Enumerable.Empty<string>();
}