using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Repository;

namespace OCASWeb
{
    public class Startup
    {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

    public IConfiguration Configuration { get; }


    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }


    public void ConfigureServices(IServiceCollection services)
     {

      string connection = @"Server=.\SQLEXPRESS;Database=OcasAssignment;Trusted_Connection=True;";
      services.AddDbContext<OcasAssignmentContext>(options => options.UseSqlServer(connection));
      
      services.AddMvc();
      services.AddTransient<ICompanyActivityRepository, CompanyActivityRepository>();
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) => {
                await next();
                if (context.Response.StatusCode == 404 &&
                   !Path.HasExtension(context.Request.Path.Value) &&
                   !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseMvcWithDefaultRoute();
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
