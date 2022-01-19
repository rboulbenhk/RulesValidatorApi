using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RulesValidatorApi.Service.v1.Options;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(options => 
        {
            options.EnableEndpointRouting = false;
            options.Filters.Add<ValidationFilter>();
        })
        .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<Startup>());

        services.AddSwaggerGen(s => {
            s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo{Title="RulesValidatorApi", Version="v1"});
        });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        // if (env.IsDevelopment())
        // {
        //     app.UseDeveloperExceptionPage();
        // }
        // else
        // {
        //     app.UseExceptionHandler();
        // }
        var swaggerOptions = new SwaggerOptions();
        Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
        
        app.UseSwagger(o => 
        {
            o.RouteTemplate = swaggerOptions.JsonRoute;
        });
        app.UseSwaggerUI(o => o.SwaggerEndpoint(swaggerOptions.UIEndPoint,swaggerOptions.Description));
        app.UseStatusCodePages();
        app.UseMvc();
    }
}