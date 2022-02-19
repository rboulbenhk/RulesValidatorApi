namespace RulesValidatorApi.Application.Validators;

public readonly record struct ErrorValidation(string code, string message);

public static class Errors
{
    public static ErrorValidation InvalidFilePath(string filePath) => new ErrorValidation("postRuleSetRequest.filePath", $"'{filePath}' doesn't exist.");
    public static ErrorValidation InvalidFilePath(object filePathValue) => new ErrorValidation("postRuleSetRequest.filePath", $"'{filePathValue}' is not correct.");
    public static ErrorValidation InvalidFilePathExtension(string currentExtension, string filePath) => new ErrorValidation("postRuleSetRequest.filePath", $"'{currentExtension}' is not a valid file extension. It should be a csv file.");
    public static ErrorValidation InvalidColumnId(int columnId) => new ErrorValidation("postRuleSetRequest.columnId", $"'{columnId}' must be greater than 1.");
    public static ErrorValidation InvalidRuleName(string ruleName) => new ErrorValidation("postRuleSetRequest.ruleName", $"'{ruleName}' doesn't exist");
    public static ErrorValidation MissingArguments(string ruleName, IEnumerable<string> possibleArgumentValues) => new ErrorValidation("postRuleSetRequest.argumentValues", $"'{ruleName}' must have some arguments e.g. '{string.Join(", ", possibleArgumentValues)}'");
    public static ErrorValidation BadRuleSetArguments(string argumentValue, string ruleName, IEnumerable<string> possibleArgumentValues) => new ErrorValidation("postRuleSetRequest.argumentValues", $"'{argumentValue}' is not valid for the rule='{ruleName}'. You can use '{string.Join(", ", possibleArgumentValues)}'");

    public static ErrorValidation RuleSetHasNoArgument(string ruleName, IEnumerable<string> argumentValues) => new ErrorValidation("postRuleSetRequest.argumentValues", $"'{ruleName}' must not have argument values. '{string.Join(", ", argumentValues)}'");
}
