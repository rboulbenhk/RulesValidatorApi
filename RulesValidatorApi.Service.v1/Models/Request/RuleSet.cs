using Newtonsoft.Json;

namespace RulesValidatorApi.Service.Models.Request
{
    public class RuleSet
    {
        [JsonProperty("ColumnId")]
        public int ColumnId { get; set; }

        [JsonProperty("RuleName")]
        public string? RuleName { get; set; }

        [JsonProperty("RuleValue")]
        public string? RuleValue { get; set; }
    }
}