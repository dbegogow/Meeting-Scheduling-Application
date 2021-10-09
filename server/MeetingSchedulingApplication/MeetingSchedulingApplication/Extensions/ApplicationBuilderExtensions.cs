using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MeetingSchedulingApplication.Data;
using MeetingSchedulingApplication.Data.Models;
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

            var data = services
                .GetRequiredService<MeetingSchedulingApplicationDbContext>();

            MigrateDatabase(data);
            SeedRooms(data);

            return app;
        }

        private static void MigrateDatabase(MeetingSchedulingApplicationDbContext data)
            => data?.Database.Migrate();

        private static void SeedRooms(MeetingSchedulingApplicationDbContext data)
        {
            var rooms = data
                .Rooms;

            if (rooms.Any())
            {
                return;
            }

            rooms.AddRange(new()
            {
                Name = "Iskar",
                Capacity = 8,
                AvailableFrom = TimeSpan.Parse("09:00"),
                AvailableTo = TimeSpan.Parse("18:00")
            }, new()
            {
                Name = "Maritsa",
                Capacity = 6,
                AvailableFrom = TimeSpan.Parse("12:00"),
                AvailableTo = TimeSpan.Parse("20:00")
            }, new()
            {
                Name = "Danube",
                Capacity = 12,
                AvailableFrom = TimeSpan.Parse("12:00"),
                AvailableTo = TimeSpan.Parse("20:00")
            }, new()
            {
                Name = "Yantra",
                Capacity = 4,
                AvailableFrom = TimeSpan.Parse("09:00"),
                AvailableTo = TimeSpan.Parse("18:00")
            });

            data.SaveChanges();
        }
    }
}
