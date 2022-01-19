namespace RulesValidatorApi.Service.Models.Request
{
    public class CsvConfigurationForValidationDto
    {
        public string? FilePath { get; set; }
        public RuleSet[]? RuleSet { get; set; }
    }
}