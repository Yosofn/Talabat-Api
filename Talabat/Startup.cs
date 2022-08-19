using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talabat.BLL.Interface;
using Talabat.BLL.Reposatories;
using Talabat.DAL.Data;
using Talabat.Helper;

namespace Talabat
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


            services.AddDbContext<StoreContext>(
                options =>
                {

                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });
            services.AddSingleton < IConnectionMultiplexer>(s=>
            { 
                var connection = ConfigurationOptions.Parse(Configuration.GetConnectionString("Redis"));
                
            return ConnectionMultiplexer.Connect(connection);
        
        });

             services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Talabat", Version = "v1" });
            });
            services.AddScoped(typeof(IGenaricReposatory<>), typeof(GenaricReposatory<>));
            services.AddAutoMapper(typeof(MappingProfile));

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Talabat v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

           // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
