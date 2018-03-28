using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnionNetCore.Core.Mapper;
using Swashbuckle.AspNetCore.Swagger;

namespace OnionNetCore.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(Microsoft.AspNetCore.Server.HttpSys.HttpSysDefaults.AuthenticationScheme);
            services.AddSingleton(Configuration);
            Infrastructure.IoC.Domain.GetInstance.Initiate(services, Configuration).Load();

            services.AddMvc();

            services.AddSwaggerGen(configure => { configure.SwaggerDoc("v1", new Info { Title = "API", Version = "v1" }); });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AutoMapperApp.ConfigureAutoMapper();

            loggerFactory.AddFile("Logs/NetCore-{Date}.txt");

            app.UseSwagger();

            app.UseSwaggerUI(configure => { configure.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"); });

            app.UseMvc();
        }
    }
}
