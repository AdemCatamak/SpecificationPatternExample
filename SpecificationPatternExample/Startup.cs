using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SpecificationPatternExample.Api.Controllers;
using SpecificationPatternExample.ConfigSection;
using SpecificationPatternExample.Data;

namespace SpecificationPatternExample
{
    public class Startup
    {
        private const string ALLOWED_ORIGIN_POLICY = "AllowedOriginPolicy";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
                             {
                                 options.AddPolicy(ALLOWED_ORIGIN_POLICY,
                                                   builder =>
                                                   {
                                                       builder.AllowAnyHeader()
                                                              .AllowAnyMethod()
                                                              .AllowAnyOrigin();
                                                   });
                             });

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                                       {
                                           options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                                           options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                                           options.SerializerSettings.StringEscapeHandling = StringEscapeHandling.Default;
                                           options.SerializerSettings.TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full;
                                           options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                                           options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                                           options.SerializerSettings.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;
                                       })
                    .AddApplicationPart(typeof(HomeController).Assembly);


            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo()); });


            string connectionString = AppConfigs.GetDbConnectionString();

            services.AddDbContext<DataContext>((provider, builder) =>
                                               {
                                                   builder.UseSqlServer(connectionString);
                                                   builder.UseLoggerFactory(provider.GetService<ILoggerFactory>())
                                                          .EnableSensitiveDataLogging();
                                               });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", ""); });
            app.UseRouting();
            app.UseCors(ALLOWED_ORIGIN_POLICY);
            app.UseEndpoints(builder => { builder.MapControllers(); });
        }
    }
}