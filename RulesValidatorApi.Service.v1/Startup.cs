using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RulesValidatorApi.Service.v1.SetUp;
using Swashbuckle.AspNetCore.Swagger;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.SetUpServices(Configuration);
        services.AddAutoMapper(typeof(Startup)); 
        services.AddMediatR(typeof(Startup));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        var swaggerOptions = new RulesValidatorApi.Service.OptionsApi.SwaggerOptions();
        Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
        
        app.UseSwagger(o => 
        {
            o.RouteTemplate = swaggerOptions.JsonRoute;
        });
        app.UseSwaggerUI(o => o.SwaggerEndpoint(swaggerOptions.UIEndPoint, swaggerOptions.Description));
        app.UseStatusCodePages();
        app.UseMvc();
    }
}