using System.Collections.Generic;

namespace RulesValidatorApi.Service.Domains.Request
{
    public class RuleSet
    {
        public int ColumnId { get; set; }
        public string RuleName { get; set; } = string.Empty;
        public IEnumerable<string>? Arguments { get; set; }
    }
}