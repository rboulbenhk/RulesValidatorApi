using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RulesValidatorApi.Service.OptionsApi;
using RulesValidatorApi.Service.v1.Rules;

namespace RulesValidatorApi.Service.v1.SetUp
{
    public class ConfigurationSetUp : ISetUp
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.Configure<MaxNumberOfResponseOptions>(configuration.GetSection(MaxNumberOfResponseOptions.SectionName));
            services.Configure<IEnumerable<RuleSetOptions>>(configuration.GetSection(RuleSetOptions.SectionName));
        }
    }
}