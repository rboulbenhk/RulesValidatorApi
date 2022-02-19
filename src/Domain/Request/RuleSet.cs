namespace RulesValidatorApi.Domain.Request;

public class RuleSet
{
    public int ColumnId { get; set; }
    public string RuleName { get; set; } = string.Empty;
    public IEnumerable<string> Arguments { get; set; } = Enumerable.Empty<string>();
}