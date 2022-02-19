

namespace RulesValidatorApi.Infrastructure.Logger;

public static class LoggerExtensions
{
    public static IDisposable TimedOperation<T>(this ILogger<T> logger, LogLevel logLevel, string message, params object?[] args) => new TimeLogOperation<T>(logger, logLevel, message, args);
    public static IDisposable DebugTimedOperation<T>(this ILogger<T> logger, string message, params object?[] args) => new TimeLogOperation<T>(logger, LogLevel.Debug, message, args);
}
