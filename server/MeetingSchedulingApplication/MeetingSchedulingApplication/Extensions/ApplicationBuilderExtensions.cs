using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MeetingSchedulingApplication.Data;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingSchedulingApplication.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
           this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services
                .GetRequiredService<MeetingSchedulingApplicationDbContext>();

            data?.Database.Migrate();
        }
    }
}
