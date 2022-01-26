namespace RulesValidatorApi.Service.v1.Domains.Response
{
    public class CsvRulesResponse
    {
        public string RuleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IEnumerable<string> PossibleArgumentValues { get; set; } = Enumerable.Empty<string>();
    }
}