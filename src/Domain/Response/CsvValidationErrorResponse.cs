namespace RulesValidatorApi.Domain.Response;

public class CsvValidationErrorResponse
{
    public string Message { get; set; } = string.Empty;
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}