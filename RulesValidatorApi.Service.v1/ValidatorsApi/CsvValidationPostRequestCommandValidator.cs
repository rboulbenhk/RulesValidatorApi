using System.IO;
using System.IO.Abstractions;
using FluentValidation;
using Microsoft.Extensions.Options;
using RulesValidatorApi.Service.v1.ValidatorsApi;

namespace RulesValidatorApi.Service.ValidatorsApi
{
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

            RuleForEach(rule => rule.RuleSet).SetValidator(new PostRuleSetRequestValidator(_ruleSetOptions.CurrentValue));
        }
    }
}