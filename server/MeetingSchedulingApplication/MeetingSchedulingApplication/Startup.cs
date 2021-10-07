using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MeetingSchedulingApplication.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingSchedulingApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MeetingSchedulingApplication", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage()
                    .UseSwagger()
                    .UseSwaggerUI(c =>
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MeetingSchedulingApplication v1"));
            }

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
