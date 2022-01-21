using System.Collections.Generic;

namespace RulesValidatorApi.Service.v1.Contracts.V1.Requests
{
    public class CsvValidationPostRequest
    {
        public string? FilePath { get; set; }
        public IEnumerable<PostRuleSetRequest> RuleSet { get; set; } = new List<PostRuleSetRequest>();
    }
}