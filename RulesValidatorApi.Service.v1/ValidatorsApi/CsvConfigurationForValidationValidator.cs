using System.IO;
using FluentValidation;
using RulesValidatorApi.Service.Domains.Request;

namespace RulesValidatorApi.Service.ValidatorsApi
{
    public class CsvConfigurationForValidationValidator : AbstractValidator<CsvConfigurationForValidation>
    {
        public CsvConfigurationForValidationValidator()
        {
            RuleFor(rule => rule.FilePath)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Matches("*.csv").WithMessage("{PropertyName} should contain a path with a csv file extension")
            .Must(IsFilePathExists).WithMessage("{PropertyName} should contain a valid path for csv file to load");

            RuleForEach(rule => rule.RuleSet)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .ChildRules(ruleSet =>
                {
                    ruleSet.RuleFor(x => x.ColumnId).GreaterThan(0).WithMessage("ColumnId {CollectionIndex} must be correct");
                    ruleSet.RuleFor(x => x.RuleName)
                .NotEmpty()
                .Must(IsRuleNameValid)
                .WithMessage("RuleName {CollectionIndex} must be correct");
                });
        }

        private bool IsFilePathExists(string filePath) => File.Exists(filePath);

        private bool IsRuleNameValid(string? ruleName)
        {
            return true;
        }
    }
}