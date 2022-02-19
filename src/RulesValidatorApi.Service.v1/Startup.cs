using Infrastructure;
using RulesValidatorApi.Application.DependencyInjection;
using RulesValidatorApi.Domain.Rules;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        //services.AddControllers();        
        services.AddApplication();
        services.AddApplicationConfigurations(Configuration);

        services.AddAInfrastructure();

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
        
        app.UseEndpoints(endpoints => {            
            endpoints.MapControllers();
            endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
        });     
    }
}