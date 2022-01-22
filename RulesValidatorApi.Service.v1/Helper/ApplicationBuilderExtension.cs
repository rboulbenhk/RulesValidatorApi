using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace RulesValidatorApi.Service.v1.Helper
{
    public static class ApplicationBuilderExtension
    {
        public static void UseFluentValidationExceptionHendler(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(e =>
            {
                e.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature?.Error;

                    if(exception is not ValidationException validationException)
                    {
                        throw exception;
                    }
                    
                    var error = JsonSerializer.Serialize(validationException.ValidationResult.ErrorMessage);
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = "applicaton/json";
                    await context.Response.WriteAsync(error, Encoding.UTF8);
                });
            });
        }
        
    }
}