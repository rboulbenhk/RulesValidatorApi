namespace RulesValidatorApi.Service.Domains.Request
{
    public class CsvConfigurationForValidation
    {
        public string? FilePath { get; set; }
        public RuleSet[]? RuleSet { get; set; }
    }
}