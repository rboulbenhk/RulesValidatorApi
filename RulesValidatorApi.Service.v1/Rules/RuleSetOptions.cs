using System.Collections.Generic;
using System.Linq;

namespace RulesValidatorApi.Service.v1.Rules
{
    public class RuleSetOptions
    {
        public const string SectionName = "RuleSetCsvValidation";
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Example { get; set; } = string.Empty;
        public string ArgumentRegex { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
    }
}