﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Mysql.Repositories;
using Clinic.Services;
using Management.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Clinic.API
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


            services.AddCors();
            services.AddCors(options => options.AddPolicy("Access-Control-Allow-Origin", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials()
                    .Build();
            }));



            var mainConstring = Configuration.GetSection("Logging:ConnectionString:default");
            var constring = mainConstring.Value;



            var factory = new MysqlRepositoryFactory(constring);
            factory.AddMember<IAccountsRepository,AccountRepository>();
            factory.AddMember<IPersonRepository, PersonRepository>();


            services.AddTransient(typeof(IServiceResource<string>), x => factory);
            services.AddTransient<IAccountsService, AccountService<string>>();
            services.AddTransient<IPersonService, PersonService<string>>();

            ////swagger 
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Clinic API",
                        Description = "Clinic API",
                        Version = "v1"
                    });
                s.DescribeAllEnumsAsStrings();
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                //../swagger/v1/
                s.SwaggerEndpoint("../swagger/v1/swagger.json", "Clinic API");
            });

            app.UseCors("Access-Control-Allow-Origin");

            app.UseMvc();
        }
    }
}
