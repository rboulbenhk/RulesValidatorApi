using Newtonsoft.Json;

namespace RulesValidatorApi.Service.Domains.Request
{
    public class RuleSet
    {
        public int ColumnId { get; set; }
        public string? RuleName { get; set; }
        public string? RuleValue { get; set; }
    }
}