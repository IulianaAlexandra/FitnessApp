using FitnessAppWebAPI.Models;
using FitnessAppWebAPI.Services;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData;
using Microsoft.OData.Edm;
using System;
using System.Linq;

namespace FitnessAppWebAPI
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
            services.AddDbContext<improvedfitnessappContext>(options =>
                 options.UseMySQL(Configuration.GetConnectionString("ImprovedFitnessAppDb"))
            );
            services.AddScoped<MuscleGroupService>();
            services.AddOData();
            services.AddMvc();

            services.AddControllers(options =>
            {
                options.EnableEndpointRouting = false;
            });
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

            app.UseMvc(routes =>
            {
                routes.EnableDependencyInjection();
                routes.Select().Filter().OrderBy().MaxTop(100).Count().SkipToken().Expand();
            
            });
        }
    }
}
