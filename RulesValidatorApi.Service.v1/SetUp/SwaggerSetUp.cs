using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RulesValidatorApi.Service.Contracts.V1;
using Swashbuckle.AspNetCore.Filters;

namespace RulesValidatorApi.Service.v1.SetUp
{
    public class SwaggerSetUp : ISetUp
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSwaggerGen(s => {
                s.SwaggerDoc(ApiRoutes.Version, new Microsoft.OpenApi.Models.OpenApiInfo{Title=ApiRoutes.Title, Version=ApiRoutes.Version});
                s.ExampleFilters();
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory,xmlFile);
                s.IncludeXmlComments(xmlPath);
            });

            services.AddSwaggerExamplesFromAssemblyOf<Startup>();
        }
    }
}