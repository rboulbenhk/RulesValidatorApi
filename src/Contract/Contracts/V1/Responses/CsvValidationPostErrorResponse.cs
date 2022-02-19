namespace RulesValidatorApi.Contract.Contracts.V1.Responses;
public class CsvValidationPostErrorResponse
{
    public string Message { get; set; } = string.Empty;
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}