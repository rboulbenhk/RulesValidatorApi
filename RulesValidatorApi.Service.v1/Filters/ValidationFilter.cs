using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

public class ValidationFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if(!context.ModelState.IsValid)
        {
            var errorResponse = BuildErrorResponse(context.ModelState);
            context.Result = new BadRequestObjectResult(errorResponse);
            return;
        }
        await next();
    }

    private ErrorResponse BuildErrorResponse(ModelStateDictionary modelState)
    {
        var errorResponse = new ErrorResponse();

        var errors = modelState
        .Where(m => m.Value.Errors.Count > 0)
        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(_ => _.ErrorMessage))
        .ToArray();

        foreach(var error in errors)
        {
            foreach(var subError in error.Value)
            {
                var errorModel = new ErrorModel
                {
                    FieldName = error.Key,
                    Message = subError
                };
                errorResponse.Errors.Add(errorModel);
            }
        } 
        return errorResponse;
    }

}