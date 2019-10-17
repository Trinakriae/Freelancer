using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Freelancer.Business.Interfaces;
using Freelancer.Business.Models;
using Freelancer.Business.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Freelancer.Business
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
            services.AddMvc();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            { 
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                builder.AllowCredentials();
            }));

            services.Configure<MvcOptions>(option =>
            {
                option.Filters.Add(new CorsAuthorizationFilterFactory("MyPolicy"));
            });

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddMemoryCache();

            //Dependency Injection
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInvoiceService, InvoiceService>();

            //Database Context Injection
            services.AddDbContext<EFContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FreelancerDB")));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API Business - Freelancer", Version = "v1" });
                c.CustomSchemaIds(r => r.FullName);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/ts-{Date}.txt");

            app.UseCors("MyPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "API Business - Freelancer");
            });
        }
    }
}
