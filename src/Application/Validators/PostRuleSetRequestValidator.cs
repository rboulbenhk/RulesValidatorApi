

namespace RulesValidatorApi.Application.Validators;

public class PostRuleSetRequestsValidator : AbstractValidator<IEnumerable<PostRuleSetRequest>>
{
    public PostRuleSetRequestsValidator(IEnumerable<RuleSetOptions> ruleSetOptions)
    {
        RuleForEach(ruleSetRequest => ruleSetRequest)
            .SetValidator(new PostRuleSetRequestValidator(ruleSetOptions));
    }
}

public class PostRuleSetRequestValidator : AbstractValidator<PostRuleSetRequest>
{
    public PostRuleSetRequestValidator(IEnumerable<RuleSetOptions> ruleSetOptions)
    {
        CascadeMode = CascadeMode.Stop;
        RuleFor(x => x)
        .NotNull()
        .Custom((ruleSetRequest, context) =>
        {
            if (ruleSetRequest.ColumnId < 1)
            {
                context.AddFailure(Errors.InvalidColumnId(ruleSetRequest.ColumnId));
                return;
            }
            var ruleSet = ruleSetOptions.FirstOrDefault(r => string.Equals(r.RuleName, ruleSetRequest.RuleName, System.StringComparison.Ordinal));
            if (ruleSet == null)
            {
                context.AddFailure(Errors.InvalidRuleName(ruleSetRequest.RuleName));
                return;
            }
            if (string.IsNullOrWhiteSpace(ruleSet.ArgumentRegex) && ruleSetRequest.ArgumentValues.Any())
            {
                context.AddFailure(Errors.RuleSetHasNoArgument(ruleSetRequest.RuleName, ruleSetRequest.ArgumentValues));
                return;
            }
            if (!string.IsNullOrWhiteSpace(ruleSet?.ArgumentRegex))
            {
                var regex = new Regex(ruleSet.ArgumentRegex);
                var notValidArguments = AreRuleSetArgumentsValid(ruleSetRequest.ArgumentValues,
                ruleSetRequest.RuleName,
                regex,
                ruleSet.PossibleArgumentValues);
                foreach (var ruleSetArguments in notValidArguments)
                {
                    context.AddFailure(ruleSetArguments);
                }
            }
        });

        static IEnumerable<ErrorValidation> AreRuleSetArgumentsValid(IEnumerable<string> argumentsToValidate, string ruleName, Regex regex, IEnumerable<string> possibleArgumentValues)
        {
            if (!argumentsToValidate.Any())
            {
                yield return Errors.MissingArguments(ruleName, possibleArgumentValues);
            }
            else
            {
                foreach (var argumentValue in argumentsToValidate)
                {
                    if (!regex.IsMatch(argumentValue))
                    {
                        yield return Errors.BadRuleSetArguments(argumentValue, ruleName, possibleArgumentValues);
                    }
                }
            }
        }
    }
}
