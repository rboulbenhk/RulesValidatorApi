namespace RulesValidatorApi.Domain.Request;

public class CsvConfigurationForValidation
{
    public string FilePath { get; set; } = string.Empty;
    public IEnumerable<RuleSet> RuleSet { get; set; } = new List<RuleSet>();
}