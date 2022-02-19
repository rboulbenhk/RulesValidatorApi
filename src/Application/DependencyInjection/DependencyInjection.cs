namespace RulesValidatorApi.Application.DependencyInjection;

public static class DepndencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMvc(options =>
        {
            options.EnableEndpointRouting = false;
        });
        services.AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));        
        services.AddSingleton<IPostService, PostService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<IFileSystem, FileSystem>();
    }

    public static void AddApplicationConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions();
        services.Configure<MaxNumberOfResponseOptions>(configuration.GetSection(MaxNumberOfResponseOptions.SectionName));
        services.Configure<List<RuleSetOptions>>(configuration.GetSection(RuleSetOptions.SectionName));
    }
}
