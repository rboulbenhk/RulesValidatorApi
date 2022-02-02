

namespace RulesValidatorApi.Service.ValidatorsApi;

public class CsvValidationPostRequestCommandValidator : AbstractValidator<CsvValidationPostRequestCommand>
{
    private readonly IOptionsMonitor<IEnumerable<RuleSetOptions>> _ruleSetOptions;
    private readonly IFileSystem _fileSystem;

    public CsvValidationPostRequestCommandValidator(IOptionsMonitor<IEnumerable<RuleSetOptions>> ruleSetOptions, IFileSystem fileSystem)
    {
        CascadeMode = CascadeMode.Stop;
        _ruleSetOptions = ruleSetOptions;
        _fileSystem = fileSystem;

        RuleFor(rule => rule.FilePath)
        .NotEmpty()
        .FilePathValidator(_fileSystem);

        RuleFor(rule => rule.RuleSet)
        .NotNull()
        .SetValidator(new PostRuleSetRequestsValidator(_ruleSetOptions.CurrentValue));
    }
}
