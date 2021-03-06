﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Todo.Web.Infra.Context;
using Todo.Web.Infra.UnitOfWork;
using Todo.Web.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Todo.Web.Domain.Services;
using Todo.Web.Domain.Validatiors.Todo;

namespace Todo.Web
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    p => p.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddMvcCore()
                .AddJsonFormatters();

            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<UnitOfWork, UnitOfWork>();
            services.AddTransient<TodoRepository, TodoRepository>();
            services.AddTransient<TodoService, TodoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("CorsPolicy");
            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseWelcomePage();
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
