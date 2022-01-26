namespace RulesValidatorApi.Service.v1.Rules
{
    public class RuleSetOptions
    {
        public const string SectionName = "RuleSetCsvValidation";
        public string RuleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        public List<string> PossibleArgumentValues { get; set; } = new List<string>();
        public List<string> DefaultValues { get; set; } = new List<string>();
        public string ArgumentRegex { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
    }
}