

namespace RulesValidatorApi.Service.v1.SetUp;

public class ConfigurationSetUp : ISetUp
{
    public void InstallServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddOptions();
        services.Configure<MaxNumberOfResponseOptions>(configuration.GetSection(MaxNumberOfResponseOptions.SectionName));
        services.Configure<List<RuleSetOptions>>(configuration.GetSection(RuleSetOptions.SectionName));
    }
}
