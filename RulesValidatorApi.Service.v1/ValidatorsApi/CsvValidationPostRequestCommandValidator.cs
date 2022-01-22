using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Options;
using RulesValidatorApi.Service.v1.Commands;
using RulesValidatorApi.Service.v1.Rules;

namespace RulesValidatorApi.Service.ValidatorsApi
{
    public class CsvValidationPostRequestCommandValidator : AbstractValidator<CsvValidationPostRequestCommand>
    {
        private readonly IOptionsMonitor<RuleSetOptions> _ruleSetOptions;

        public CsvValidationPostRequestCommandValidator(IOptionsMonitor<RuleSetOptions> ruleSetOptions)
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
                    ruleSet.RuleFor(x => x.ColumnId).GreaterThan(0).WithMessage("ColumnId {CollectionIndex} must be correct");
                    ruleSet.RuleFor(x => x.RuleName)
                            .NotEmpty()
                            .MustAsync(IsRuleNameValid)
                            .WithMessage("RuleName {CollectionIndex} must be correct");
                });
        }

        private async Task<bool> IsFilePathExists(CsvValidationPostRequestCommand request, string filePath, CancellationToken cancellation = new CancellationToken())
        {
            return await Task.FromResult(File.Exists(filePath));
        } 

        private async Task<bool> IsRuleNameValid(string ruleName, CancellationToken cancellation = new CancellationToken())
        {
            //TODO manage collection of rules
            return await Task.FromResult(string.Equals(_ruleSetOptions.CurrentValue.RuleName,ruleName,System.StringComparison.Ordinal));
        }
    }
}