namespace RulesValidatorApi.Service.v1.Rules
{
    public class RuleSetOptions
    {
        public const string SectionName = "RuleSetCsvValidation";
        public string RuleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        public IEnumerable<string> PossibleArgumentValues { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> DefaultValues { get; set; } = Enumerable.Empty<string>();
        public string ArgumentRegex { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
    }
}