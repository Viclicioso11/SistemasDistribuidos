using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application;
using Infrastructure;
using BaseArquitecturaAPI.ApiExceptionFilter;
using AutoMapper;
using BaseArquitecturaAPI.Policies;
using BaseArquitecturaAPI.Middleware;

namespace BaseArquitecturaAPI
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

            services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(
                options => options.JsonSerializerOptions.PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance);

            services.AddApplicationDependencyInjection();

            services.AddInfrastructureDependencyInjection(Configuration);

            services.AddAutoMapper(typeof(Startup));

            services.AddCors();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseJwtMiddleware();

            app.UseRouting();           

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
