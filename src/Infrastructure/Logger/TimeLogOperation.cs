using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace RulesValidatorApi.Infrastructure.Logger;

public class TimeLogOperation<T> : IDisposable
{
    private readonly ILogger<T> _logger;
    private readonly LogLevel _logLevel;
    private readonly string _message;
    private readonly object?[] _args;
    private readonly Stopwatch _stopWatch;

    public TimeLogOperation(ILogger<T> logger, LogLevel logLevel, string message, object?[] args)
    {
        _logger = logger;
        _logLevel = logLevel;
        _message = message;
        _args = args;
        _stopWatch = Stopwatch.StartNew();
    }

    public void Dispose()
    {
        _stopWatch.Stop();
        _logger.TimeOperation(_logLevel,string.Format(_message,_args),_stopWatch.ElapsedMilliseconds);
    }
}
