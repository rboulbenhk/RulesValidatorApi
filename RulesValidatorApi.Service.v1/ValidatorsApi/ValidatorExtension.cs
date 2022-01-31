using FluentValidation;

namespace RulesValidatorApi.Service.v1.ValidatorsApi
{
    public static class ValidationExt
    {
        public static void AddFailure(this ValidationContext<PostRuleSetRequest> context, ErrorValidation errorValidation)
        {
            context.AddFailure($"{errorValidation.code} {errorValidation.message}");
        }

        public static void AddFailure<T>(this ValidationContext<T> context, ErrorValidation errorValidation)
        {
            context.AddFailure($"{errorValidation.code} {errorValidation.message}");
        }
    }
}