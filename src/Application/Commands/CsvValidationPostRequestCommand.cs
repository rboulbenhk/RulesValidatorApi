namespace RulesValidatorApi.Application.Commands;

public class CsvValidationPostRequestCommand : IRequest<ValidateableResponse<IEnumerable<CsvValidationPostErrorResponse>>>, IValidateable
{
    public string FilePath { get; set; } = string.Empty;
    public IEnumerable<PostRuleSetRequest> RuleSet { get; set; } = default!;
}