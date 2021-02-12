using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.GitHub.Application;
using Desafio.GitHub.CrossCutting.Settings;
using Desafio.GitHub.Domain;
using Desafio.GitHub.Domain.Facades;
using Desafio.GitHub.Domain.Facades.Interfaces;
using Desafio.GitHub.Domain.Infrastructure;
using Desafio.GitHub.Domain.Infrastructure.Interfaces;
using Desafio.GitHub.Domain.Integration;
using Desafio.GitHub.Domain.Interfaces;
using Desafio.GitHub.Domain.Repositories;
using Desafio.GitHub.Domain.Repositories.Interface;
using Desafio.GitHub.Integration.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Desafio.GitHub.WebApi2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepositorioIntegration, RepositorioIntegration>();
            services.AddScoped<IRepositorioFacade, RepositorioFacade>();
            services.AddScoped<IRepositorioService, RepositorioService>();
            services.AddScoped(typeof(RepositorioApplication));
            
            services.AddScoped<IDesafioUnitOfWork, DesafioUnitOfWork>();
            services.AddScoped<IRepositorioFavoritadoRepository, RepositorioFavoritadoRepository>();
            

            services.AddControllers();
            services.AddApiVersioning();

            services.Configure<ApiSettings>(options => Configuration.GetSection("ApiSettings").Bind(options));

            #region Swagger

            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.UseApiBehavior = false;
                o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "API - V1", Version = "v1" });

                c.OperationFilter<RemoveVersionFromParameter>();

                c.DocumentFilter<ReplaceVersionWithExactValueInPath>();

                c.DocInclusionPredicate((version, desc) =>
                {
                    var versions = desc.CustomAttributes()
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);

                    var maps = desc.CustomAttributes()
                        .OfType<MapToApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions)
                        .ToArray();

                    return versions.Any(v => $"v{v.ToString()}" == version) && (maps.Length == 0 || maps.Any(v => $"v{v.ToString()}" == version));
                });
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1.0/swagger.json", name: "v1");
            });
        }
    }

    public class RemoveVersionFromParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var versionParameter = operation.Parameters.Single(p => p.Name == "version");
            operation.Parameters.Remove(versionParameter);
        }
    }

    public class ReplaceVersionWithExactValueInPath : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = new OpenApiPaths();
            foreach (var path in swaggerDoc.Paths)
            {
                paths.Add(path.Key.Replace("v{version}", swaggerDoc.Info.Version), path.Value);
            }
            swaggerDoc.Paths = paths;
        }
    }
}
