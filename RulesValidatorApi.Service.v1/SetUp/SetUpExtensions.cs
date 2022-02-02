namespace RulesValidatorApi.Service.v1.SetUp;

public static class SetUpExtensions
{
    public static void SetUpServices(this IServiceCollection services, IConfiguration configuration)
    {
        var setUpInstances = typeof(Startup).Assembly.ExportedTypes.Where(t => typeof(ISetUp).IsAssignableFrom(t)
        && !t.IsInterface
        && !t.IsAbstract).Select(Activator.CreateInstance).Cast<ISetUp>().ToList();
        //TODO check if it is needed
        services.AddEndpointsApiExplorer();
        setUpInstances.ForEach(s => s.InstallServices(configuration, services));
    }
}
