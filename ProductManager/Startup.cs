using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProductManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProductManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            using (var client = new ProductManagerDBContext())
            {
                client.Database.EnsureCreated();
            }
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore((option =>
            {
                option.CacheProfiles.Add("Default", new CacheProfile()
                {
                    Duration = 120,
                    Location = ResponseCacheLocation.Any
                });
            }));
            services.AddCors();
            services.AddMvc();
            services.AddEntityFrameworkSqlite().AddDbContext<ProductManagerDBContext>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());
            app.UseMvc();
        }
    }
}
