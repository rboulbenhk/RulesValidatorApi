using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RulesValidatorApi.Service.Contracts.V1;
using RulesValidatorApi.Service.Filters;

namespace RulesValidatorApi.Service.v1.SetUp
{
    public class MvcSetUp : ISetUp
    {
        public void InstallService(IConfiguration configuration, IServiceCollection services)
        {
            services.AddMvc(options => 
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add<ValidationFilter>();
            })
            .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSwaggerGen(s => {
                s.SwaggerDoc(ApiRoutes.Version, new Microsoft.OpenApi.Models.OpenApiInfo{Title=ApiRoutes.Title, Version=ApiRoutes.Version});
            });
        }
    }
}