namespace RulesValidatorApi.Models.Request
{
    public class CsvConfigurationForValidationDto
    {
        public string FilePath { get; set; }
        public RuleSet[] RuleSet { get; set; }
    }
}