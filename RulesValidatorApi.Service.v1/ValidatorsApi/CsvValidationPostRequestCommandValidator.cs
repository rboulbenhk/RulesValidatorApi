using System.IO;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace RulesValidatorApi.Service.ValidatorsApi
{
    public class CsvValidationPostRequestCommandValidator : AbstractValidator<CsvValidationPostRequestCommand>
    {
        private readonly IOptionsMonitor<IEnumerable<RuleSetOptions>> _ruleSetOptions;

        public CsvValidationPostRequestCommandValidator(IOptionsMonitor<IEnumerable<RuleSetOptions>> ruleSetOptions)
        {
            _ruleSetOptions = ruleSetOptions;
            
            RuleFor(rule => rule.FilePath)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Matches("*.csv").WithMessage("{PropertyName} should contain a path with a csv file extension")
            .MustAsync(IsFilePathExists).WithMessage("{PropertyName} should contain a valid path for csv file to load");

            RuleForEach(rule => rule.RuleSet)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .ChildRules(ruleSet =>
                {
                    ruleSet.RuleFor(x => x.ColumnId)
                    .Cascade(CascadeMode.Stop)
                    .GreaterThan(0)
                    .WithMessage("ColumnId {CollectionIndex} must be correct");
                    
                    ruleSet.RuleFor(x => x.RuleName)
                            .Cascade(CascadeMode.Stop)
                            .NotEmpty()
                            .MustAsync(IsRuleNameValid)
                            .WithMessage("RuleName {CollectionIndex} must be correct");
                    
                    ruleSet.RuleFor(x => x.ArgumentValues)
                            .Cascade(CascadeMode.Stop)
                            .NotEmpty()
                            .Must(IsRuleNameArgumentsValid)
                            .WithMessage("Arguments {CollectionIndex} must be correct");     
                });
        }

        private async Task<bool> IsFilePathExists(CsvValidationPostRequestCommand request, string filePath, CancellationToken cancellation = new CancellationToken())
        {
            return await Task.FromResult(File.Exists(filePath));
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