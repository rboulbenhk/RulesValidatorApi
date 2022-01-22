using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace RulesValidatorApi.Service.v1.PipelineBehaviors
{
    // public class BadResponse : ValidationBehaviorResult<>
    // {

    // }

    // public interface ValidationBehaviorResult<T> where T : class
    // {        
    // }

    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;
        
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators.Select(v => v.Validate(context))
            .SelectMany(v => v.Errors)
            .Where(v => v != null).ToList();

            if(failures.Any())
            {
                //TODO not return a Result<TResponse> the bad version of the Result not the good version BadRe 
                //throw new ValidationException(failures);  
            }
            return next();
        }
    }
}