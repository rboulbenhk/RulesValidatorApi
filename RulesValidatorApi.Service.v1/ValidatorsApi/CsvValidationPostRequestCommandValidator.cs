using System.IO;
using System.IO.Abstractions;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace RulesValidatorApi.Service.ValidatorsApi
{
    public class CsvValidationPostRequestCommandValidator : AbstractValidator<CsvValidationPostRequestCommand>
    {
        private readonly IOptionsMonitor<IEnumerable<RuleSetOptions>> _ruleSetOptions;
        private readonly IFileSystem _fileSystem;

        public CsvValidationPostRequestCommandValidator(IOptionsMonitor<IEnumerable<RuleSetOptions>> ruleSetOptions, IFileSystem fileSystem)
        {
            _ruleSetOptions = ruleSetOptions;
            _fileSystem = fileSystem;
            RuleFor(rule => rule.FilePath)
            .NotEmpty()
            .MustAsync(IsFilePathExists).WithMessage("{PropertyName} should contain a valid path for csv file to load");

            RuleForEach(rule => rule.RuleSet)
            .NotNull()
            .NotEmpty()
            .ChildRules(ruleSet =>
                {
                    ruleSet.RuleFor(x => x.ColumnId)
                    .GreaterThan(0)
                    .WithMessage("ColumnId {CollectionIndex} must be correct");
                    
                    ruleSet.RuleFor(x => x.RuleName)
                            .NotEmpty()
                            .MustAsync(IsRuleNameValid)
                            .WithMessage("RuleName {CollectionIndex} must be correct");
                    
                    ruleSet.RuleFor(x => x.ArgumentValues)
                            .NotEmpty()
                            .Must(IsRuleNameArgumentsValid)
                            .WithMessage("Arguments {CollectionIndex} must be correct");     
                });
        }

        private async Task<bool> IsFilePathExists(CsvValidationPostRequestCommand request, string filePath, CancellationToken cancellation = new CancellationToken())
        {
            return await Task.FromResult(_fileSystem.File.Exists(filePath));
        } 

        private async Task<bool> IsRuleNameValid(string ruleName, CancellationToken cancellation = new CancellationToken())
        {            
            return await Task.FromResult(_ruleSetOptions.CurrentValue.Select(r => r.RuleName).Any(rule => string.Equals(rule,ruleName,System.StringComparison.Ordinal)));
        }

        private bool IsRuleNameArgumentsValid(IEnumerable<string>? arguments)
        {   
            if(arguments == null || arguments.Any())
            {
                return true;
            }

            //TODO we need to check the arguments of the rule
            return true;
        }
    }
}