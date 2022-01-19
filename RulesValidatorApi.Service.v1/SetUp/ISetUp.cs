using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RulesValidatorApi.Service.v1.SetUp
{
    public interface ISetUp
    {
        void InstallService(IConfiguration configuration, IServiceCollection services);
    }
}