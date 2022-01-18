using Newtonsoft.Json;

namespace RulesValidatorApi.Models.Request
{
    public class RuleSet
    {
        [JsonProperty("ColumnId")]
        public int ColumnId { get; set; }

        [JsonProperty("RuleName")]
        public string RuleName { get; set; }

        [JsonProperty("RuleValue")]
        public string RuleValue { get; set; }
    }
}