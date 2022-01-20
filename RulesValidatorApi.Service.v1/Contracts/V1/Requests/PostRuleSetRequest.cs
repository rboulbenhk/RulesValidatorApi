using System.Collections.Generic;

namespace RulesValidatorApi.Service.v1.Contracts.V1.Requests
{
    public class PostRuleSetRequest
    {
        public int ColumnId { get; set; }

        public string? RuleName { get; set; }

        public IList<string>? Argument { get; set; } = new List<string>();
    }
}