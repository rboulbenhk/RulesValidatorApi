using FluentValidation;

namespace RulesValidatorApi.Service.v1.PipelineBehaviors
{

    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, IValidateable
    where TResponse : class
    {
        private readonly IValidator<TRequest> _compositeValidator;
        private readonly ILogger<TRequest> _logger;

        public ValidationBehavior(IValidator<TRequest> compositeValidator, ILogger<TRequest> logger)
        {
            _compositeValidator = compositeValidator;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var result = await _compositeValidator.ValidateAsync(request, cancellationToken);

            if (!result.IsValid)
            {
                var messages = result.Errors.Select(s => s.ErrorMessage);
                var errorMessage = string.Join(",\n",messages);
                _logger.LogError($"Error during validation : {errorMessage}");

                var responseType = typeof(TResponse);

                if (responseType.IsGenericType)
                {
                    var resultType = responseType.GetGenericArguments()[0];
                    var invalidResponseType = typeof(ValidateableResponse<>).MakeGenericType(resultType);

                    var invalidResponse =
                        Activator.CreateInstance(invalidResponseType, null, messages.ToList()) as TResponse;

                    if(invalidResponse == null)
                    {
                        _logger.LogError($"Unable to return an invalid response for : {errorMessage}");
                    }

                    return invalidResponse!;
                }
            }

            var response = await next();

            return response;
        }
    }
}