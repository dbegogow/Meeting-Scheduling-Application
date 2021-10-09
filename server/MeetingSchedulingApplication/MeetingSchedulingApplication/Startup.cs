using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MeetingSchedulingApplication.Data;
using Microsoft.Extensions.Configuration;
using MeetingSchedulingApplication.Extensions;
using Microsoft.Extensions.DependencyInjection;
using MeetingSchedulingApplication.Services.Slots;
using MeetingSchedulingApplication.Services.Rooms;

namespace MeetingSchedulingApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<MeetingSchedulingApplicationDbContext>(options => options
                    .UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MeetingSchedulingApplication", Version = "v1" }));

            services
                .AddTransient<IRoomsService, RoomsService>()
                .AddTransient<ISlotsService, SlotsService>();

            services.AddCors(options =>
            {
                var frontendUrl = this.Configuration.GetValue<string>("frontend_url");

                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithOrigins(frontendUrl)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("totalAmountOfRecords");
                });
            });
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
                .UseCors()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
