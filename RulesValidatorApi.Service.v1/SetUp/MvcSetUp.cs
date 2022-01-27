global using FluentValidation.AspNetCore;
global using RulesValidatorApi.Service.v1.PipelineBehaviors;
using System.IO.Abstractions;
using FluentValidation;

namespace RulesValidatorApi.Service.v1.SetUp
{
    public class MvcSetUp : ISetUp
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddMvc(options => 
            {
                options.EnableEndpointRouting = false;                
            });
            services.AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<Startup>());
            ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;
            services.AddSingleton<IPostService,PostService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(Startup));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<IFileSystem,FileSystem>();
        }
    }
}