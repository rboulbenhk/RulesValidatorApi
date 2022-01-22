using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RulesValidatorApi.Service.v1.SetUp;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddOptions();
        services.SetUpServices(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        
        app.UseStaticFiles();
        
        var swaggerOptions = new RulesValidatorApi.Service.OptionsApi.SwaggerOptions();
        Configuration.GetSection(nameof(RulesValidatorApi.Service.OptionsApi.SwaggerOptions)).Bind(swaggerOptions);
        

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/csv/swagger.json", swaggerOptions.Description);
            options.RoutePrefix = string.Empty;
        });


        // app.UseSwagger(o =>
        // {
        //     o.RouteTemplate = swaggerOptions.JsonRoute;
        // });
        // app.UseSwaggerUI(o => {
        //     o.SwaggerEndpoint(swaggerOptions.UIEndPoint, swaggerOptions.Description);
        //     //o.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        //     //o.RoutePrefix = string.Empty;

        // });        
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseStatusCodePages("text/html", "We're <b>really</b> sorry, but something went wrong. Error code: {0}");
    }
}