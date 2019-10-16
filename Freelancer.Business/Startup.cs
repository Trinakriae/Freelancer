﻿using System;
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


            //Dependency Injection
            services.AddScoped<IAllocatedTimeService, AllocatedTimeService>();
            services.AddScoped<IProjectService, ProjectService>();

            //Database Context Injection
            services.AddDbContext<EFContext>(options => options.UseSqlite("Data Source=blog.db"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
        }
    }
}
