using System.Collections.Generic;
namespace RulesValidatorApi.Service.Domains.Request
{
    public class CsvConfigurationForValidation
    {
        public string? FilePath { get; set; }
        public IEnumerable<RuleSet> RuleSet { get; set; } = new List<RuleSet>();
    }
}