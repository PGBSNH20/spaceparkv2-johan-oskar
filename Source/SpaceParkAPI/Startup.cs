using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SpaceParkAPI.Middleware;
using SpaceParkAPI.Models;
using SpaceParkAPI.Repositories;

namespace SpaceParkAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SpaceParkContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpaceParkAPI", Version = "v1" });
            });
            services.AddSingleton<IParkingsRepository, ParkingsRepository>();
            //services.AddSingleton<ISpaceportRepository, SpaceportRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpaceParkAPI v1"));
            }

            app.UseHttpsRedirection();

            //app.Use(async (context, next) =>
            //{
                //if (context.Request.Headers.ContainsKey("apikey") && context.Request.Headers["apikey"].ToString() == "secret1234")
                //{
                //    await next();
                //}
                //else
                //{
                //    context.Response.StatusCode = 401;
                //}
            //});

            app.UseApiKeyMiddleware();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
