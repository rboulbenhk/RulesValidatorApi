using RulesValidatorApi.Service.Models.Request;

namespace RulesValidatorApi.Service.v1.Contracts.V1.Requests
{
    public class CsvValidationPostRequest
    {
        public string? FilePath { get; set; }
        public RuleSet[]? RuleSet { get; set; }
    }
}