using RulesValidatorApi.Contract.Contracts.V1.Requests;

namespace RulesValidatorApi.Application.Validators;

public static class ValidationExt
{
    public static void AddFailure(this ValidationContext<PostRuleSetRequest> context, ErrorValidation errorValidation) => context.AddFailure($"{errorValidation.code} {errorValidation.message}");
    public static void AddFailure<T>(this ValidationContext<T> context, ErrorValidation errorValidation) => context.AddFailure($"{errorValidation.code} {errorValidation.message}");
}
