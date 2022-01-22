using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RulesValidatorApi.Service.Contracts.V1;
using Swashbuckle.AspNetCore.Filters;

namespace RulesValidatorApi.Service.v1.SetUp
{
    public class SwaggerSetUp : ISetUp
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("csv", new OpenApiInfo {
                    Title = "CSV File Validator API",
                    Version = ApiRoutes.Version
                });
            });

            // services.AddSwaggerGen(s => 
            // {
            //     s.SwaggerDoc(ApiRoutes.Version, new OpenApiInfo
            //     {
            //         Title=ApiRoutes.Title, 
            //         Version=ApiRoutes.Version,
            //         Description="My Api"
            //     });
            //     var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //     s.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            // });            
            // services.AddSwaggerExamplesFromAssemblyOf<Startup>();
        }
    }
}