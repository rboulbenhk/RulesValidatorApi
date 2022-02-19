namespace RulesValidatorApi.Service.v1.SetUp;

public interface ISetUp
{
    void InstallServices(IConfiguration configuration, IServiceCollection services);
}
