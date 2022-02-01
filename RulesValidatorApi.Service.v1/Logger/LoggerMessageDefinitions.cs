namespace RulesValidatorApi.Service.v1.Logger;

public static partial class LoggerMessageDefinitions
{
    [LoggerMessage(EventId=0, Level = LogLevel.Debug, Message = "Start GetAllRulesAsync")]
    public static partial void StartGetAllRulesAsync(this ILogger logger);
    
    [LoggerMessage(EventId=0, Level = LogLevel.Debug, Message = "End GetAllRulesAsync")]
    public static partial void EndGetAllRulesAsync(this ILogger logger);

    [LoggerMessage(EventId=0, Level = LogLevel.Debug, Message = "Start ValidateAsync")]
    public static partial void StartValidateAsync(this ILogger logger);
    
    [LoggerMessage(EventId=0, Level = LogLevel.Debug, Message = "End ValidateAsync")]
    public static partial void EndValidateAsync(this ILogger logger);

    [LoggerMessage(EventId=0, Level = LogLevel.Critical, Message = "Exception occured while validating the CSV file {filePath} with {configuration}.")]
    public static partial void ExceptionValidateAsync(this ILogger logger, Exception ex, string filePath, string configuration);
    
    
    [LoggerMessage(EventId=0, Level = LogLevel.Error, Message = "Error during validation:'{errorMessage}'")]
    public static partial void ValidationError(this ILogger logger, string errorMessage);
    
    [LoggerMessage(EventId=0, Level = LogLevel.Error, Message = "Unable to return a valid response:'{errorMessage}'")]
    public static partial void UnableToReturnValidResponse(this ILogger logger, string errorMessage);
    
    [LoggerMessage(EventId=0, Level = LogLevel.Debug, Message = "Max number of response retrieve from settings:'{numberOfResponse}'")]
    public static partial void MaxNumberOfResponse(this ILogger logger, int? numberOfResponse);
    
    [LoggerMessage(EventId=0, Level = LogLevel.Debug, Message = "RuleSetValues from settings:'{ruleSet}'")]
    public static partial void RuleSetValues(this ILogger logger, string ruleSet);
    
    [LoggerMessage(EventId=0, Level = LogLevel.Debug, Message = "Start PostValidateAsync'")]
    public static partial void StartPostValidateAsync(this ILogger logger);

    [LoggerMessage(EventId=0, Level = LogLevel.Debug, Message = "End PostValidateAsync'")]
    public static partial void EndPostValidateAsync(this ILogger logger);
    
    [LoggerMessage(EventId=0, Message = "'{message}' completed in {timeSpan}ms")]
    public static partial void TimeOperation(this ILogger logger, LogLevel level, string message, long timeSpan);


}

 