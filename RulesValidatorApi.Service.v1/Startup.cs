using FluentValidation.AspNetCore;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        
        services.AddMvc(options => 
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add<ValidationFilter>();
            })
            .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<Startup>());
        // services.AddSwaggerGen(setupAction =>
        // {
        //     setupAction.SwaggerDoc("RulesValidatorApi",);
        // });
    }

    public void Configure(IApplicationBuilder app, Microsoft.Extensions.Hosting.IHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler();
        }
        app.UseSwagger(); 
        app.UseStatusCodePages();
        app.UseMvc();
    }
}