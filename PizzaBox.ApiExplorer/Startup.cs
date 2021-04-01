using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PizzaBox.Logic;
using PizzaBox.Repository;

namespace PizzaBox.ApiExplorer
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
            string connectionString = Configuration.GetConnectionString("PizzaDB");

			// add the Db context
			services.AddDbContext<StoreContext>(options =>
			{
                if (!options.IsConfigured)
                {
                    options.UseSqlServer(connectionString);
                }
				
			});
            services.AddDbContext<CustomerContext>(options =>
			{
				if (!options.IsConfigured)
                {
                    options.UseSqlServer(connectionString);
                }
			});
            services.AddDbContext<OrderContext>(options =>
			{
				if (!options.IsConfigured)
                {
                    options.UseSqlServer(connectionString);
                }
			});
            
			services.AddScoped<StoreLogic>();
			services.AddScoped<StoreRepository>();
            services.AddScoped<CustomerLogic>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<OrderLogic>();
            services.AddScoped<OrderRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaBox.ApiExplorer", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaBox.ApiExplorer v1"));
            }

            app.UseStatusCodePages();

            app.UseHttpsRedirection();

            // use this to  redirect to the index HTML for any random path
			app.UseRewriter(new RewriteOptions()
				.AddRedirect("^$", "index.html"));

			// use the .js static files (find out what 'static' means)
			app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
