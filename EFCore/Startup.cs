using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using EFCoreDal.Models;
using EFCoreBll;
using Microsoft.EntityFrameworkCore;

namespace EFCore
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
            services.AddControllers();

            services.AddScoped(typeof(IContactDl), typeof(ContactDl));
            services.AddScoped(typeof(IContactBll), typeof(ContactBll));




            ////services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddScoped(typeof(IContactDl), typeof(ContactDl));
            //services.AddScoped(typeof(IContactBll), typeof(ContactBll));


            services.AddDbContext<myDBContext>(option => option.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=myDB;Integrated Security=True;Pooling=False"));
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
