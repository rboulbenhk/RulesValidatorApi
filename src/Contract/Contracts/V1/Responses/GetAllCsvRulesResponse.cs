namespace RulesValidatorApi.Contract.Contracts.V1.Responses;
public class GetAllCsvRulesResponse
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IEnumerable<string> PossibleArgumentValues { get; set; } = Enumerable.Empty<string>();
}