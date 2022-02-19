namespace RulesValidatorApi.Application.Validators;

public static class CustomValidators
{
    public static IRuleBuilderOptions<T, TElement> FilePathValidator<T, TElement>
    (this IRuleBuilder<T, TElement> ruleBuilder, IFileSystem fileSystem)
    {
        return (IRuleBuilderOptions<T, TElement>)ruleBuilder.Custom((value, context) =>
        {
            if (value is not string filePath)
            {
                context.AddFailure(Errors.InvalidFilePath(value!));
                return;
            }

            if (!fileSystem.File.Exists(filePath))
            {
                context.AddFailure(Errors.InvalidFilePath(filePath));
                return;
            }

            var currentExtension = Path.GetExtension(filePath);
            if (!string.Equals(currentExtension, ".csv", StringComparison.Ordinal))
            {
                context.AddFailure(Errors.InvalidFilePathExtension(currentExtension, filePath));
                return;
            }
        });
    }
}
