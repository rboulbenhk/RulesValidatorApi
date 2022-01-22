using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RulesValidatorApi.Service.v1.Rules;
using RulesValidatorApi.Service.v1.Services;

namespace RulesValidatorApi.Service.v1.SetUp
{
    public class MvcSetUp : ISetUp
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddMvc(options => 
            {
                options.EnableEndpointRouting = false;                
            })
            .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSingleton<IPostService,PostService>();

            var ruleSetOptions = configuration.GetSection(RuleSetOptions.SectionName).Get<RuleSetOptions>();
            services.AddSingleton(ruleSetOptions);
        }
    }
}