global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using RulesValidatorApi.Service.v1.SetUp;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        //services.AddControllers();        
        services.SetUpServices(Configuration);
        services.AddControllers();
        services.AddOptions();
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
        
        //app.UseStaticFiles();
        
        var swaggerOptions = new RulesValidatorApi.Service.OptionsApi.SwaggerOptions();
        Configuration.GetSection(nameof(RulesValidatorApi.Service.OptionsApi.SwaggerOptions)).Bind(swaggerOptions);
        
        var myOPtions = new MaxNumberOfResponseOptions();
        Configuration.GetSection(MaxNumberOfResponseOptions.SectionName).Bind(myOPtions);

        var myRuleSet = new List<RuleSetOptions>();
        Configuration.GetSection(RuleSetOptions.SectionName).Bind(myRuleSet);

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
        //app.UseStatusCodePages("text/html", "We're <b>really</b> sorry, but something went wrong. Error code: {0}");   
        app.UseEndpoints(endpoints => {            
            endpoints.MapControllers();
            endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
        });     
    }
}